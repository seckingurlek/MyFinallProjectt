using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constrait kısıtlama sadece entity için
    // class referans tip anlamında, newlenebilen bişi olmalı
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        //filtreleme çubuğu gibisinden tget ise tek bi filtreleme gerektirdiğinden hepsi ortak
        List<T> GetAll(Expression<Func<T,bool >> filter =null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
