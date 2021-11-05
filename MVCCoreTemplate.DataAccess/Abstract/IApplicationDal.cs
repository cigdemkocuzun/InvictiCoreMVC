
using MVCCoreTemplate.Core.EntityFramework;
using MVCCoreTemplate.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCCoreTemplate.DataAccess.Abstract
{
    public interface IApplicationDal : IEntityRepository<Application> //dataAccessLayer
    {
    }
}
