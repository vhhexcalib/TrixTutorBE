﻿using BusinessObject;
using Microsoft.AspNetCore.Http;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITutorInformationService
    {
        Task<dynamic> GetProfile(CurrentUserObject currentUserObject);
        Task<dynamic> UploadAvatar(IFormFile attachmentFile, CurrentUserObject currentUserObject);
        Task<dynamic> CreateTutorInformation(CurrentUserObject currentUserObject, TutorInformationDTO tutorInformationDTO);
        Task<dynamic> GetProfileById(int id);
        Task<dynamic> GetTutorWallet(CurrentUserObject currentUserObject);
        Task<dynamic> UpdateProfile(CurrentUserObject currentUserObject, EditTutorProfileDTO tutorProfileDTO);
    }
}
