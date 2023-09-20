using AutoMapper;
using BLL.Model;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            //CreateMap<Film, FilmModel>().ForMember(e => e.ImagesModel, opt => opt.MapFrom(src => src.Images))
            //.ForMember(x=>x.CategoriesModel,opt=>opt.MapFrom(src=>src.Categories)).ReverseMap();
            //CreateMap<Image, ImageModel>().ReverseMap();  

            CreateMap<Delivery, DeliveryModel>()
                .ForMember(e=>e.ProductsModel, q=>q.MapFrom(s=>s.Products))
                .ForMember(e=>e.DeliveryProductsModel, q=>q.MapFrom(s=>s.DeliveryProducts))
                .ReverseMap();
            //CreateMap<Delivery, DeliveryModel>().ReverseMap();
            
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Product, ProductDetail>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<User, UserDataModel>().ReverseMap();
            CreateMap<DeliveryProducts, DeliveryProductsModel>().ReverseMap();
            CreateMap<Comment, CommentModel>().ReverseMap();
        }
    }
}
