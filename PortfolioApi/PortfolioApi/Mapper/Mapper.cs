using AutoMapper;
using PortfolioApi.Api.Admin.AdminDTOs.ABlogDto;
using PortfolioApi.Api.Admin.AdminDTOs.AContactDto;
using PortfolioApi.Api.Admin.AdminDTOs.AContactMessageDto;
using PortfolioApi.Api.Admin.AdminDTOs.AEducationDto;
using PortfolioApi.Api.Admin.AdminDTOs.APortfolioUserDto;
using PortfolioApi.Api.Admin.AdminDTOs.ASkillDto;
using PortfolioApi.Api.Admin.AdminDTOs.ASocialDto;
using PortfolioApi.Api.Admin.AdminDTOs.ATagDto;
using PortfolioApi.Api.Admin.AdminDTOs.AWorkExperience;
using PortfolioApi.Api.Client.DTOs;
using PortfolioApi.Api.Client.DTOs.BlogDto;
using PortfolioApi.Api.Client.DTOs.ContactDto;
using PortfolioApi.Api.Client.DTOs.ContactMessageDto;
using PortfolioApi.Api.Client.DTOs.EducationDto;
using PortfolioApi.Api.Client.DTOs.PortfolioUserDto;
using PortfolioApi.Api.Client.DTOs.SkillDto;
using PortfolioApi.Api.Client.DTOs.UserWithContactGetDto;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<PortfolioUser, UserWithContactGetDto>();
            CreateMap<Contact, ContactGetDto>();
            CreateMap<MessageCreateDto, ContactMessage>();
            CreateMap<Blog, BlogGetDto>();
            CreateMap<PortfolioUser, PortUserGetDto>();
            CreateMap<PortfolioUser, PortUserAboutGetDto>();
            CreateMap<WorkExperience, WorkExperienceAboutGetDto>();
            CreateMap<Skill, SkillAboutGetDto>();
            CreateMap<Education, EducationAboutDto>();
            CreateMap<Contact, AContactGetDto>();
            CreateMap<Contact, AContactMessageGetDto>();
            CreateMap<ContactMessage, AContactMessageGetDto>();
            CreateMap<PortfolioUser, APortfolioUserGetDto>();
            CreateMap<APortfolioUserCreateDto, PortfolioUser>();
            CreateMap<AContactCreateDto, Contact>();
            CreateMap<ASocialCreateDto, Social>();
            CreateMap<Social, ASocialGetDto>();
            CreateMap<WorkExperience, AWorkExperinceGetDto>();
            CreateMap<AWorkExperienceCreateDto, WorkExperience>();
            CreateMap<Education, AEducationGetDto>();
            CreateMap<AEducationCreateDto, Education>();
            CreateMap<Skill, ASkillGetDto>();
            CreateMap<ASkillCreateDto, Skill>();
            CreateMap<Tag, ATagGetDto>();
            CreateMap<ATagCreateDto, Tag>();
            CreateMap<Blog, ABlogGetDto>();
            CreateMap<ABlogCreateDto, Blog>();
            CreateMap<ABlogCreateDto, Tag>();
            CreateMap<ContactMessage, ContactMessageItemDto>();
            CreateMap<Skill, SkillGetDtoItem>();










        }

    }
}
