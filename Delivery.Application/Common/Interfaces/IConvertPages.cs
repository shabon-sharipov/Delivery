//using Delivery.Application.Common.Interfaces;
//using Delivery.Application.Respons.PaggedList;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Delivery.Application.Common.Interfaces
//{
//    public interface IConvertPages<TEntity,TResult>
//    {
//        PaggedList<TResult> ApplyAndGetPaggedList(int pageSize, int pageNamber, IQueryable<TEntity> entities );
//    }
//}

//public class ConvertPages<TEntity, TResult> : IConvertPages<TEntity, TResult>
//{
//    public PaggedList<TResult> ApplyAndGetPaggedList(int pageSize, int pageNamber, IQueryable<TEntity> entities)
//    {
        
//        var totalCount=entities.Count();
//        var totalPage= (int)Math.Ceiling(totalCount / (double)pageSize);
//        var result =

//        throw new NotImplementedException();
//    }
//}