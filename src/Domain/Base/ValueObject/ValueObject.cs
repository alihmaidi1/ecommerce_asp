using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Base.ValueObject
{
    public abstract class ValueObject:IEquatable<ValueObject>
    {
        public  bool Equals(ValueObject? other)
        {
            if (other == null || other.GetType() != GetType())
                return false;

            var ValueObject = (ValueObject)other;
            return GetValues().SequenceEqual(ValueObject.GetValues());
            
        }



        public static bool operator ==(ValueObject left,ValueObject right)
        {


            return left.Equals(right);  
        }


        public static bool operator !=(ValueObject left, ValueObject right)
        {

            return !left.Equals(right);

        }

        


        public abstract IEnumerable<object> GetValues();



    }
}
