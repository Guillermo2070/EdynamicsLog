﻿using EdynamicsLog.Entities.Interfaces;
using EdynamicsLog.RepositoryEFCore.DataContext;

namespace EdynamicsLog.RepositoryEFCore.Repositories
{
    public class UnitOfWorkProducts : IUnitOfWorkProducts
    {
        readonly EdynamicsLogProductsContext Context;

        public UnitOfWorkProducts(EdynamicsLogProductsContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<int> SaveChanges()
        {
            try
            {
                return Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al intentar guardar los cambios en la base de datos.", ex);
            }
        }
    }
}
