using MVCCoreTemplate.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCCoreTemplate.Business.Abstract
{
    public interface IApplicationService
    {
        List<Application> GetAll();

        Application GetById(int id);

        int Insert(Application obj);

        int Update(Application obj);

        int Delete(Application obj);
    }
}
