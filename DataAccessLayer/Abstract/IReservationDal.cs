using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal: IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id); //,Odobreniye,soglasiye,Onay

        List<Reservation> GetListWithReservationByAccepted(int id);    //Prinyal, kabul edilmiş

        List<Reservation> GetListWithReservationByPrevious(int id);   //Predıduşiy, Önceski 
    }
}
