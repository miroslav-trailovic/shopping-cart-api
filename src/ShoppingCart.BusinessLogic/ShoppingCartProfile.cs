using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.BusinessLogic
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<DataModel.PromotionCode, BusinessModel.PromotionCode>();
            CreateMap<DataModel.Customer, BusinessModel.Customer>();
            CreateMap<DataModel.Article, BusinessModel.Article>();

            CreateMap<DataModel.CartItem, BusinessModel.CartItem>();
            CreateMap<BusinessModel.CartItem, DataModel.CartItem>()
                .ForMember(t => t.Article, opt => opt.Ignore())
                .ForMember(t => t.Customer, opt => opt.Ignore());
        }
    }
}
