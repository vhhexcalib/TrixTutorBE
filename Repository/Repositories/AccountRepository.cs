using BusinessObject;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly TrixTutorDBContext _context;
        public AccountRepository(TrixTutorDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Account> LoginAsync(string email, string password)
        {

            return await _context.Account.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
        }
        public async Task<Account> GetAccountByEmail(string email)
        {

            return await _context.Account.FirstOrDefaultAsync(a => a.Email == email);
        }
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _context.Account.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> CheckPhoneExistAsync(string phone)
        {
            return await _context.Account.AnyAsync(x => x.Phone == phone);
        }

        public async Task<bool> CreateAccount(Account account)
        {
            try
            {
                await _context.Account.AddAsync(account);
                var result = await _context.SaveChangesAsync();
                return result > 0; // Returns true if changes were saved successfully
            }
            catch
            {
                return false; // Returns false if an exception occurs
            }
        }
        public async Task<IEnumerable<Account>> GetAllAccountsAsync(Expression<Func<Account, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByBirthdayAsc = true)
        {
            IQueryable<Account> query = _context.Set<Account>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tìm kiếm theo Account Name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search));
            }

            // Sắp xếp theo Birthday
            query = sortByBirthdayAsc
                ? query.OrderBy(a => a.Birthday)
                : query.OrderByDescending(a => a.Birthday);

            // Bao gồm các navigation properties (nếu có)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Phân trang
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAvailableTutorAsync(Expression<Func<Account, bool>>? filter = null, string? includeProperties = null, int page = 1, int size = 10, string? search = null, bool sortByBirthdayAsc = true, string flag = "")
        {
            // Base query: Lọc các tài khoản không bị cấm, đã xác nhận email, và có Role là Tutor (RoleId = 4)
            IQueryable<Account> query = _context.Set<Account>()
                .Where(x => x.IsBan == false && x.IsEmailConfirm == true && x.RoleId == 4);

            // Áp dụng filter bổ sung (nếu có)
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (flag.Equals(""))
            {
                // Tìm kiếm theo tất cả biến
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(a => a.Address.Contains(search)
                    || a.TutorInformation.TutorCategory.Name.Contains(search)
                    || a.Name.Contains(search)
                    );
                }
            }
            if (flag.Equals("Name"))
            {
                // Tìm kiếm theo tên tài khoản 
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(a => a.Name.Contains(search));
                }
            }
            if (flag.Equals("Subject"))
            {
                // Tìm kiếm theo tên danh mục gia sư
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(a => a.TutorInformation.TutorCategory.Name.Contains(search));
                }
            }
            if (flag.Equals("Address"))
            {
                // Tìm kiếm theo tên địa chỉ
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(a => a.Address.Contains(search));
                }
            }
            // Sắp xếp theo ngày sinh (Birthday)
            query = sortByBirthdayAsc
                ? query.OrderBy(a => a.Birthday)
                : query.OrderByDescending(a => a.Birthday);

            // Tự động bao gồm các navigation properties cần thiết (TutorInformation và TutorCategory)
            query = query.Include(a => a.TutorInformation)
                         .ThenInclude(ti => ti.TutorCategory);

            // Bao gồm các navigation properties khác (nếu có thêm thông qua includeProperties)
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Phân trang
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
        public async Task<int> CountAsync(string? search = null)
        {
            IQueryable<Account> query = _context.Set<Account>();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search));
            }

            return await query.CountAsync();
        }

        public async Task<int> CountTutorsAsync(string? search = null, string flag = "")
        {
            IQueryable<Account> query = _context.Set<Account>()
                .Where(x => x.IsBan == false && x.IsEmailConfirm == true && x.RoleId == 4);

            if (flag.Equals("Name") && !string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search));
            }
            if (flag.Equals("Subject") && !string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.TutorInformation.TutorCategory.Name.Contains(search));
            }
            if (flag.Equals("Address") && !string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Address.Contains(search));
            }
            if (string.IsNullOrEmpty(flag) && !string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search) ||
                                         a.TutorInformation.TutorCategory.Name.Contains(search) ||
                                         a.Address.Contains(search));
            }

            return await query.CountAsync();
        }


    }
}
