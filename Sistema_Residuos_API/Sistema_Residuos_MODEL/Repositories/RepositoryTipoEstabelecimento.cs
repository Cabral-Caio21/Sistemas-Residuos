﻿using Sistema_Residuos_MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Residuos_MODEL.Repositories
{
    public class RepositoryTipoEstabelecimento : RepositoryBase<TiposEstabelecimento>
    {
        public RepositoryTipoEstabelecimento(Sistema_ResiduosContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }
    }
}