using MVCCoreTemplate.Business.Abstract;
using MVCCoreTemplate.DataAccess.Abstract;
using MVCCoreTemplate.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCCoreTemplate.Business.Concrete
{
    public class ApplicationManager : IApplicationService
    {
        private IApplicationDal _applicationDal;

        public ApplicationManager(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }

        public int Delete(Application obj)
        {
            return _applicationDal.Delete(obj);
        }

        public List<Application> GetAll()
        {
            return _applicationDal.GetList();
        }

        public Application GetById(int id)
        {
            return _applicationDal.GetById(x => x.ApplicationId == id);
        }

        public int Insert(Application obj)
        {
            return _applicationDal.Insert(obj);
        }

        public int Update(Application obj)
        {
            return _applicationDal.Update(obj);
        }
    }
}
