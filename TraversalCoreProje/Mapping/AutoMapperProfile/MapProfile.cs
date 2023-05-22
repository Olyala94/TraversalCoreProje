using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();

            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();

            CreateMap<AppUserLoginDTOs, AppUser>();
            CreateMap<AppUser, AppUserLoginDTOs>();

            CreateMap<AnnouncementListDTOs, Announcement>();
            CreateMap<Announcement, AnnouncementListDTOs>();

            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();

            CreateMap<SendMessageDto, ContactUs>().ReverseMap();  //yukardeki işlemin kısa halinde yazılışı
            
        } 
    }
}
