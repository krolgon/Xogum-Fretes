using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xogum.Dominio;
using Xogum.ViewModels.Motorista;
using Xogum.ViewModels.TiposUsuario;
using Xogum.ViewModels.Usuario;

namespace Xogum.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        public ViewModelParaDominioProfile()
        {
            CreateMap<TiposUsuarioExibicaoViewModel, TipoUsuario>();
            CreateMap<TiposUsuarioViewModel, TipoUsuario>();

            CreateMap<UsuarioExibicaoViewModel, Usuario>();
            CreateMap<UsuarioViewModel, Usuario>();

            CreateMap<MotoristaViewModel, Usuario>();
            //Mapper.CreateMap<Album, AlbumIndexViewModel>();
        }
    }
}