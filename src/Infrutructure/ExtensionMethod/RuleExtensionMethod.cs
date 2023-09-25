//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Reflection;
//using System.Linq.Expressions;
//using ecommerce.Domain.Base.Entity;
//using tables.Base.Entity;
//using AutoMapper.Internal;
//using ecommerce.Domain.Base.ValueObject;

//namespace ecommerce.infrutructure.ExtensionMethod
//{
//    public static class RuleExtensionMethod
//    {


//        public static bool IsUnique<T>(this ApplicationDbContext Context,string ColumnName,object ColumnValue,Guid Id=default) where T : BaseEntity<StronglyTypeId>
//        {
         
            
//            //get column
//            var Column=typeof(T).GetProperty(ColumnName);
            

//            //throw if not exists
//            if (Column == null)
//            {
//                throw new Exception($"{ColumnName} is not not correct");
//            }
//            //get type
//            var ColumnType=Column.PropertyType;

            
            
//            if(ColumnType == typeof(int))
//            {

//                return !Context.Set<T>().Any(x=>Column.GetValue(x)==ColumnValue&&x.Id!=Id);
//            }


//            if (ColumnType == typeof(string))
//            {

//                return !Context.Set<T>().Any(x => Column.GetValue(x,null).ToString().Equals(ColumnValue)&& x.Id!=Id);
//            }

//            return false;
//        }



//    }
//}
