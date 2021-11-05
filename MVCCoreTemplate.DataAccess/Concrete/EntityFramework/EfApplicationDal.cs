
using MVCCoreTemplate.Core.EntityFramework;
using MVCCoreTemplate.DataAccess.Abstract;
using MVCCoreTemplate.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MVCCoreTemplate.DataAccess.Concrete.EntityFramework
{
    public class EfApplicationDal : EfEntityRepositoryBase<Application, DatabaseContext>, IApplicationDal
    {

    }
}
