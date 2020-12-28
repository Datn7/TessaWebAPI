using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Dtos;
using TessaWebAPI.Entities;

namespace TessaWebAPI.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration configuration;

        //add configuration to access appsetings ApiUrl key 'http
        public ProductUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {

            //check pictureurl string and return with apiurl + that path to image
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
