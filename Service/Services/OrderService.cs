using AutoMapper;
using BusinessObject;
using Repository.Interfaces;
using Service.Common;
using Service.DTOs;
using Service.DTOs.AccountDTO;
using Service.DTOs.CoursesDTO;
using Service.DTOs.OrderDTO;
using Service.Exceptions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<dynamic> CreateOrderAsync(CurrentUserObject currentUserObject, CreateOrderDTO createOrderDTO)
        {
            var orderId = RandomOrderId(currentUserObject.AccountId, createOrderDTO.CourseId, createOrderDTO.TutorId);
            var existedOrder = await _unitOfWork.OrderRepository.GetOrderByStudentId(currentUserObject.AccountId);
            var learningHistoryCourse = await _unitOfWork.LearningHistoryRepository.GetAsync(x => x.CourseId == createOrderDTO.CourseId, "Course");
            var learningschedule = await _unitOfWork.LearningScheduleRepository.GetAsync(x => x.CourseId == createOrderDTO.CourseId, "Course");

            if (existedOrder != null)
            {
                return Result.Failure(OrderErrors.ExistedOrder);
            }
            var existedUnCanceledOrder = await _unitOfWork.OrderRepository.GetUnCanceledOrderByStudentId(currentUserObject.AccountId);
            if (existedUnCanceledOrder != null)
            {
                return Result.Failure(OrderErrors.UnfinishedOrder);
            }
            var existedCourse = await _unitOfWork.CoursesRepository.GetByIdAsync(createOrderDTO.CourseId);
            if (existedCourse == null)
            {
                return Result.Failure(CoursesErrors.FailGetById);
            }
            var existedTutor = await _unitOfWork.TutorInformationRepository.GetByIdAsync(createOrderDTO.TutorId);
            if (existedTutor == null)
            {
                return Result.Failure(TutorErrors.FailGetById);
            }
            if (learningschedule != null)
            {
                if (existedCourse.TeachingDateId == learningschedule.Course.TeachingDateId || learningHistoryCourse.Course.TeachingDateId == learningschedule.Course.TeachingDateId)
                {
                    if (existedCourse.TeachingDateId == learningschedule.Course.TeachingTimeId || learningHistoryCourse.Course.TeachingTimeId == learningschedule.Course.TeachingTimeId)
                    {
                        return Result.Failure(OrderErrors.OngoingCourse);
                    }
                }
            }
            var createdOrder = _mapper.Map<Order>(createOrderDTO);
            createdOrder.OrderId = orderId;
            createdOrder.StudentId = currentUserObject.AccountId;
            createdOrder.OrderDate = DateTime.Now;
            createdOrder.Status = false;
            createdOrder.IsCanceled = false;
            await _unitOfWork.OrderRepository.AddAsync(createdOrder);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(OrderErrors.CreateOrderFail);
        }
        public async Task<PagedResult<StudentOrderDTO>> GetAllStudentOrdersAsync(CurrentUserObject currentUserObject)
        {
            var orders = await _unitOfWork.OrderRepository.GetOrdersByStudentId(currentUserObject.AccountId);
            var totalItems = await _unitOfWork.OrderRepository.CountAsync(); // Đếm tổng số đơn thuê phù hợp
            return new PagedResult<StudentOrderDTO>
            {
                Items = _mapper.Map<IEnumerable<StudentOrderDTO>>(orders),
                TotalItems = totalItems
            };
        }
        public async Task<dynamic> GetOrderDetail(CurrentUserObject currentUserObject, OrderDTO orderDTO)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderDetailById(orderDTO.OrderId, currentUserObject.AccountId);
            if (order == null)
            {
                return Result.Failure(OrderErrors.OrderNotFound);
            }
            var orderDetail = _mapper.Map<OrderDetailDTO>(order);
            return Result.SuccessWithObject(orderDetail);
        }
        public string RandomOrderId(int studentId, int courseId, int tutorId)
        {
            Random rnd = new Random();
            int newOtp = rnd.Next(100000, 999999);
            string orderid = newOtp.ToString() + studentId.ToString() + courseId.ToString() + tutorId.ToString();
            return orderid;
        }
        public async Task<dynamic> CancelOrder(CurrentUserObject currentUserObject, OrderDTO orderDTO)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderDetailById(orderDTO.OrderId, currentUserObject.AccountId);
            if (order == null)
            {
                return Result.Failure(OrderErrors.OrderNotFound);
            }
            if (order.Status)
            {
                return Result.Failure(OrderErrors.FinishedPaymentOrder);
            }
            order.Status = true;
            order.IsCanceled = true;
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            var result = await _unitOfWork.SaveAsync();
            return result == "Save Change Success" ? Result.Success() : Result.Failure(OrderErrors.CancelOrderFail);
        }
    }
}
