using AutoMapper;
using Scutum.Library.Security;
using Scutum.Model;
using Scutum.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scutum.WebAPI.Mappers
{
    public class CartaoCreditoProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<CartaoCreditoViewModel, CartaoCredito>()
                .ForMember(x => x.NumeroCriptografado, x => x.ResolveUsing(
                    model => CryptographyAES.Encrypt(model.Numero, model.Senha)
                ));

            this.CreateMap<CartaoCredito, CartaoCreditoViewModel>()
                .ForMember(x => x.Numero, x => x.ResolveUsing(
                    viewModel => CryptographyAES.Decrypt(viewModel.NumeroCriptografado, viewModel.Senha)
                ));
        }
    }
}