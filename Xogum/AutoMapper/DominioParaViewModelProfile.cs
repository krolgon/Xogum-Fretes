using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xogum.Dominio;
using Xogum.ViewModels.TiposUsuario;
using Xogum.ViewModels.Usuario;

namespace Xogum.AutoMapper
{
    public class DominioParaViewModelProfile:Profile
    {
        public DominioParaViewModelProfile()
        {
            CreateMap<TipoUsuario, TiposUsuarioExibicaoViewModel>();
            CreateMap<TipoUsuario, TiposUsuarioViewModel>();

            CreateMap<Usuario, UsuarioExibicaoViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            //Mapper.CreateMap<Album, AlbumIndexViewModel>();
        }
    }
}