using AutoMapper;
using MicroServiceTask.Model;
using MicroServiceTask.Model.CommonModel;
using MicroServiceTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceTask.AutoMappingConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskModel, GetTaskDto>();
          
        }
    }
}
