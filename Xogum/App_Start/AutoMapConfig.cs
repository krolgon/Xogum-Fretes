using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xogum.AutoMapper;

namespace Xogum.App_Start
{
    public class AutoMapConfig
    {
        public static void Configurar()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DominioParaViewModelProfile>();
                cfg.AddProfile<ViewModelParaDominioProfile>();
                //outros Profiles devem ser informados aqui
            });
            //Mapper.AddProfile<DominioParaViewModelProfile>();
        }
    }
}