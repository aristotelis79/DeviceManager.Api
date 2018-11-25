﻿using System;
using System.Text.RegularExpressions;
using AutoMapper.Configuration;
using DeviceManager.Api.Data.Model;
using DeviceManager.Api.Helpers;
using DeviceManager.Api.Model;

namespace DeviceManager.Api.Mappings
{
    /// <summary>
    /// Contains objects mapping
    /// </summary>
    /// <seealso cref="AutoMapper.Configuration.MapperConfigurationExpression" />
    public class MapsProfile : MapperConfigurationExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapsProfile"/> class
        /// </summary>
        public MapsProfile()
        {
            // Device ViewModel To Device
            this.CreateMap<DeviceViewModel, Device>()
                .ForMember(dest => dest.DeviceTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DeviceId, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.DeviceCode) 
                                                                            && Regex.IsMatch(src.DeviceCode, Constants.IsGuidRegexExp) 
                                                                                ? new Guid(src.DeviceCode) 
                                                                                : Guid.NewGuid() ));
        }
    }
}
