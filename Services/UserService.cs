using ArcherLogic_Salon_Solution.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserByIDAsync(int id);
        Task<List<HowDidYouFindUsDropDownListViewModel>> LoadMediaDDL();
        Task<List<UserViewModel>> GetAllUser();
        Task<UserViewModel> AddUser(UserBindingModel userModel);
        Task<UserDAL> ModelBindingValidationCheck(UserBindingModel bindingModel, UserDAL ef);
        Task<bool> DeleteUser(int id);
        Task<UserViewModel> UpdateUser(int id, UserBindingModel ef);
    }

    public class UserService:IUserService
    {
        public readonly IConfiguration _config;
        public readonly IUserRepository userRepository;
        public readonly IMediaRepository mediaRepository;
        public readonly IPhotoRepository photoRepository;
        public UserService(IUserRepository userRepository, IMediaRepository mediaRepository, IPhotoRepository photoRepository)
        {
            this.userRepository = userRepository;
            this.mediaRepository = mediaRepository;
            this.photoRepository = photoRepository;
        }
        public async Task<List<HowDidYouFindUsDropDownListViewModel>> LoadMediaDDL()
        {
            var ddl = (from item in await mediaRepository.GetAll()
                        select new HowDidYouFindUsDropDownListViewModel
                        {
                            Id = item.ID,
                            SocialMediaName = item.NAME
                        }).ToList();

            return ddl;
        }

        public async Task<List<UserViewModel>> GetAllUser()
        {
            var allUsers = (from item in await userRepository.GetAll()
                            select new UserViewModel
                            {
                                Id = item.ID,
                                Address = item.ADDRESS,
                                DateOfBirth = item.DATE_OF_BIRTH,
                                ContactNumber = item.CONTACT_NUMBER,
                                Gender = item.GENDER,
                                UserName = item.USERNAME,
                                HowDidYouFindUsDropDownList = item.HOW_DID_YOU_FIND_US
                            }).ToList();

            return allUsers;
        }
        public async Task<UserViewModel> AddUser(UserBindingModel userModel)
        {
            UserDAL userDAL = await ModelBindingValidationCheck(userModel, new UserDAL());

            try
            {
                await userRepository.Add(userDAL);
            }
            catch (Exception ex)
            {
                throw new ConstraintException(ex.Message);
            }

            UserViewModel user = new UserViewModel()
            {
                Id = userDAL.ID,
                UserName = userDAL.USERNAME,
                DateOfBirth = userDAL.DATE_OF_BIRTH,
                Address = userDAL.ADDRESS,
                //Photo = 
                Gender = userDAL.GENDER,
                ContactNumber = userDAL.CONTACT_NUMBER,
                HowDidYouFindUsDropDownList = userDAL.HOW_DID_YOU_FIND_US

            };
            return user;
        }

        //public async Task<UserViewModel> AddUser(UserBindingModel userModel, IFormFile photo)
        //{
        //    UserDAL userDAL = await ModelBindingValidationCheck(userModel, new UserDAL());

        //    try
        //    {
        //        await userRepository.Add(userDAL);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new ConstraintException(ex.Message);
        //    }

        //    //add photo
        //    if (photo != null)
        //    {
        //        if (photo.Length > 0)
        //        {
        //            var tempPhotoName = userDAL.USERNAME + "_photo";
        //            var photoName = Convert.ToString(Guid.NewGuid()) + tempPhotoName;
        //            var photoFile = new PhotoDAL()
        //            {
        //                ID = 0,
        //                NAME = photoName,
        //                USER_ID = userDAL.ID
        //            };

        //            using (var target = new MemoryStream())
        //            {
        //                photo.CopyTo(target);
        //                photoFile.DATA = target.ToArray();
        //            }
        //            await photoRepository.Add(photoFile);
        //        }
        //    }

        //    UserViewModel user = new UserViewModel()
        //    {
        //        Id = userDAL.ID,
        //        UserName = userDAL.USERNAME,
        //        DateOfBirth = userDAL.DATE_OF_BIRTH,
        //        Address = userDAL.ADDRESS,
        //        //Photo = 
        //        Gender = userDAL.GENDER,
        //        ContactNumber = userDAL.CONTACT_NUMBER,
        //        HowDidYouFindUsDropDownList = userDAL.HOW_DID_YOU_FIND_US

        //    };
        //    return user;
        //}

        public async Task<UserDAL> ModelBindingValidationCheck(UserBindingModel bindingModel, UserDAL ef)
        {
            if(bindingModel.Address != null 
               && bindingModel.UserName != null
               && bindingModel.DateOfBirth != null
               && bindingModel.Address != null
               && bindingModel.Gender != null
               && Convert.ToString(bindingModel.ContactNumber) != null
               && bindingModel.HowDidYouFindUsDropDownList != null
                )
            {
                ef.USERNAME = bindingModel.UserName;
                ef.DATE_OF_BIRTH = bindingModel.DateOfBirth;
                ef.ADDRESS = bindingModel.Address;
                //ef.PHOTO = bindingModel.Photo;
                ef.GENDER = bindingModel.Gender;
                ef.CONTACT_NUMBER = bindingModel.ContactNumber;
                ef.HOW_DID_YOU_FIND_US = bindingModel.HowDidYouFindUsDropDownList;
                ef.IS_ACTIVE = ef.ID == 0 ? 1 : ef.IS_ACTIVE;
            }

            return ef;
        }

        public async Task<UserViewModel> GetUserByIDAsync(int id)
        {
            var user = await userRepository.GetByIDAsync(id);
            if(user != null)
            {
                UserViewModel userModel = new UserViewModel()
                {
                    UserName = user.USERNAME,
                    Address = user.ADDRESS,
                    DateOfBirth = user.DATE_OF_BIRTH,
                    ContactNumber = user.CONTACT_NUMBER,
                    Gender = user.GENDER,
                    HowDidYouFindUsDropDownList = user.HOW_DID_YOU_FIND_US,
                    Id = user.ID,
                    //Photo = user.PHOTO
                };
                return userModel;
            }
            else
            {
                string message = string.Format("No record found for user id {0}", id);
                throw new ConstraintException(message);
            }
        }
    
        public async Task<bool> DeleteUser(int id)
        {
            var user = await userRepository.GetByIDAsync(id);
            if(user != null)
            {
                await userRepository.Delete(user);
                return true;
            }
            else
            {
                string message = string.Format("No record found for user id {0} to be deleted", id);
                throw new ConstraintException(message);
            }
        }
    
        public async Task<UserViewModel> UpdateUser(int id, UserBindingModel ef)
        {
            var user = await userRepository.GetByIDAsync(id);
            if(user != null)
            {
                //user.ID = ef.Id;
                user.USERNAME = ef.UserName;
                user.ADDRESS = ef.Address;
                user.CONTACT_NUMBER = ef.ContactNumber;
                user.DATE_OF_BIRTH = ef.DateOfBirth;
                user.HOW_DID_YOU_FIND_US = ef.HowDidYouFindUsDropDownList;
                //user.PHOTO = ef.Photo;
                user.GENDER = ef.Gender;
                await userRepository.Update(user);

                UserViewModel userModel = new UserViewModel()
                {
                    UserName = ef.UserName,
                    Address = ef.Address,
                    ContactNumber = ef.ContactNumber,
                    DateOfBirth = ef.DateOfBirth,
                    HowDidYouFindUsDropDownList = ef.HowDidYouFindUsDropDownList,
                    //Photo = ef.Photo,
                    Gender = ef.Gender
                };

                return userModel;
            }
            else
            {
                string message = string.Format("No record found for user id {0} to be updated", id);
                throw new ConstraintException(message);
            }
        }

    }
}
