﻿using AutoMapper;
using AutoMapper.Configuration.Conventions;
using StudentManagement.Models.Entities;
using StudentManagement.Services.DTOs.Attendance;
using StudentManagement.Services.DTOs.Coaching;
using StudentManagement.Services.DTOs.Course;
using StudentManagement.Services.DTOs.Grade;
using StudentManagement.Services.DTOs.Training;
using StudentManagement.Services.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<UserRequest, User>()
            .ForMember(dest => dest.UserID, opt => opt.Ignore())
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));

            CreateMap<CourseRequest, Course>()
                .ForMember(dest => dest.CourseID, opt => opt.Ignore())
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<TrainingRequest, Training>()
                .ForMember(dest => dest.TrainingID, opt => opt.Ignore())
                .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<AttendanceRequest, Attendance>()
                .ForMember(dest => dest.AttendanceID, opt => opt.Ignore())
                .ForMember(dest => dest.TrainingID, opt => opt.MapFrom(src => src.TrainingID))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Present, opt => opt.MapFrom(src => src.Present));

            CreateMap<Attendance, AttendanceUserResponse>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Present, opt => opt.MapFrom(src => src.Present))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));

            CreateMap<CoachingRequest, Coaching>()
                .ForMember(dest => dest.CoachingID, opt => opt.Ignore())
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic))
                .ForMember(dest => dest.Feedback, opt => opt.MapFrom(src => src.Feedback));

            CreateMap<GradeRequest, Grade>()
                .ForMember(dest => dest.GradeID, opt => opt.Ignore())
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.TrainingID, opt => opt.MapFrom(src => src.TrainingID))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.Remarks, opt => opt.MapFrom(src => src.Remarks));
        }
    }
}
