using AutoMapper;
using EmployeesManagementApp.Models;
using EmployeesManagementApp.ViewModel;
using EmployeesManagementApp.ViewModel.AbsenceViewModels;
using EmployeesManagementApp.ViewModel.CommentViewModel;
using EmployeesManagementApp.ViewModel.SupervisorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagementApp.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Employee, EmployeeCreateViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeIndexViewModel>();
            CreateMap<Employee, EmployeeDetailViewModel>();
            CreateMap<Employee, EmployeeEditViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeDeleteViewModel>();

            CreateMap<Comment, CommentIndexViewModel>();
            CreateMap<Comment, CommentEditViewModel>().ReverseMap();
            CreateMap<Comment, CommentDetailViewModel>();
            CreateMap<Comment, CommentCreateViewModel>().ReverseMap();
            CreateMap<Comment, CommentDeleteViewModel>();

            CreateMap<Absence, AbsenceCreateViewModel>().ReverseMap();
            CreateMap<Absence, AbsenceEditViewModel>().ReverseMap();
            CreateMap<Absence, AbsenceDeleteViewModel>();
            CreateMap<Absence, AbsenceDetailViewModel>();
            CreateMap<Absence, AbsenceIndexViewModel>();

            CreateMap<Supervisor, SupervisorCreateViewModel>().ReverseMap();
            CreateMap<Supervisor, SupervisorEditViewModel>().ReverseMap();
            CreateMap<Supervisor, SupervisorDeleteViewModel>();
            CreateMap<Supervisor, SupervisorDetailViewModel>();
            CreateMap<Supervisor, SupervisorIndexViewModel>();
        }

    }
}
