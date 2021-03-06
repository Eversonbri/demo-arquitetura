﻿using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Repositorio;

namespace Demo.Infra.Repositorio
{
    public class RepositorioDeVenda
        : RepositorioBase<Venda>, IRepositorioDeVenda
    {
        #region IRepositorioDeVenda Members

        public IList<Venda> RecuperarVendasPorData(DateTime data)
        {
            return entidades.Vendas.Where(venda => venda.DataDaEmissao == data).ToList();
        }

        public IList<Venda> RecuperarVendas(DateTime? datainicial, DateTime? datafinal, int? cliente)
        {
            IQueryable<Venda> query = entidades.Vendas.AsQueryable();
            if (datainicial.HasValue)
            {
                query = query.Where(x => x.DataDaEmissao >= datainicial);
            }

            if (datafinal.HasValue)
            {
                query = query.Where(x => x.DataDaEmissao <= datafinal);
            }
            if (cliente.HasValue)
            {
                query = query.Where(x => x.Cliente.Id == cliente);
            }
            return query.ToList();
        }

        #endregion
    }
}