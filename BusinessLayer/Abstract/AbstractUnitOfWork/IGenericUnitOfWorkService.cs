using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUnitOfWork
{
    public interface IGenericUnitOfWorkService<T>
    {
        void TInsert(T t);

        void TUpdate(T t);

        void TMultiUpdate(List<T> t);
        T TGetByID(int id);
    }
}
