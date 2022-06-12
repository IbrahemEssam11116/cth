using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.Web.Models;
using SStorm.CTH.BL.Helpers;
using SStorm.CTH.DAL.HelperClasses;
using Microsoft.AspNetCore.Http;

namespace SStorm.CTH.Web.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;
        public UserService(IHttpContextAccessor context)
        {
            _context = context;
        }
        public Task<UserModel> GetAllowedUser(string userName, string password)
        {

            return Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return null;

                EntityCollection<CTHUserEntity> users = new EntityCollection<CTHUserEntity>();
                RelationPredicateBucket filter = new RelationPredicateBucket();

                string encryptedPassword = Helper.TextEncryption.Encrypt(password);
                if (userName.Contains("@") && userName.Contains(".com"))
                {

                    filter.PredicateExpression.Add(CTHUserFields.Email % userName);
                    filter.PredicateExpression.Add(CTHUserFields.Password % encryptedPassword);
                }
                else
                {

                    filter.PredicateExpression.Add(CTHUserFields.UserName % userName);
                    filter.PredicateExpression.Add(CTHUserFields.Password % encryptedPassword);
                }

                PrefetchPath2 path = new PrefetchPath2(EntityType.CTHUserEntity);
                {  // Fill Permission one time
                    path.Add(CTHUserEntity.PrefetchPathCTHUserRoleCollection)
                    .SubPath.Add(CTHUserRoleEntity.PrefetchPathCTHRoleItem)
                    .SubPath.Add(CTHRoleEntity.PrefetchPathCTHRolePermissionCollection);
                }
                CTH.BL.DataBaseClassHelper.FillCollection(users, filter, 0, null, path, 0, 0);

                var user = users.FirstOrDefault();

                if (user == null)
                    return null;
                UserModel toReturn = new UserModel()
                {

                    UserName = user.UserName,
                    FullName = user.UserName

                };
                foreach (var item in user.CTHUserRoleCollection.SelectMany(x=>x.CTHRoleItem.CTHRolePermissionCollection))
                {
                    toReturn.Permissions.Add(((UserPermission)item.PermissionID).ToString());
                }
                return toReturn;
            });

        }
        public int GetCurrentUserID()
        {
            string userName = _context.HttpContext.User.Identity.Name;
            return BL.DataBaseClassHelper.GetScaler<int>(CTHUserFields.ID, CTHUserFields.UserName % userName);
        }

        public ProfileModel profile()
        {
            EntityCollection<CTHPatientEntity> patientCollection = new EntityCollection<CTHPatientEntity>();
            EntityCollection<CTHDoctorEntity> doctorCollection = new EntityCollection<CTHDoctorEntity>();
            RelationPredicateBucket filter = new RelationPredicateBucket(CTHPatientFields.UserID == GetCurrentUserID());
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(patientCollection, filter);
            RelationPredicateBucket filter2 = new RelationPredicateBucket(CTHDoctorFields.UserID == GetCurrentUserID());
            SStorm.CTH.BL.DataBaseClassHelper.FillCollection(doctorCollection, filter2);
            if (doctorCollection.Count > 0)
            {
                ProfileModel doctor = new ProfileModel();
                doctor.doctorEntity = new CTHDoctorEntity();
                doctor.doctorEntity = doctorCollection.First();
                doctor.Type = 1;
                BL.DataBaseClassHelper.FillEntity(doctor.doctorEntity, null);
                return doctor;
            }
            else if (patientCollection.Count > 0)
            {
                ProfileModel patient = new ProfileModel();
                patient.PatientEntity = new CTHPatientEntity();
                patient.PatientEntity = patientCollection.First();
                patient.Type = 2;
                BL.DataBaseClassHelper.FillEntity(patient.PatientEntity, null);
                return patient;
            }
            else
            {
                ProfileModel user = new ProfileModel();
                user.Type = 0;
                return user;
            }
        }

    }
}
