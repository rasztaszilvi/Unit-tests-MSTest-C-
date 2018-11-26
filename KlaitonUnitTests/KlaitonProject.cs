using System;
using System.Collections.Generic;
using System.Text;

namespace KlaitonUnitTests
{
    class KlaitonProject
    {

        public enum BorderType { Low, High }

        public enum BorderRange { Day, Month, Year }

        public class BorderModel
        {
            public BorderType Type { get; set; }
            public BorderRange Range { get; set; }
        }

        public interface IInterface
        {
            /// <summary>
            /// get the low or high value in defined range included the range
            /// </summary>
            /// <param name="input">the current time </param>
            /// <param name="model">the range definition</param>
            /// <returns></returns>
            DateTime GetBorderTime(DateTime input, BorderModel model);
        }

        public class MyClass : IInterface
        {
            /// <summary>
            /// implementation of the IInterface 
            /// </summary>
            /// <param name="current"></param>
            /// <param name="model"></param>
            /// <returns></returns>
            public DateTime GetBorderTime(DateTime current, BorderModel model)
            {
                switch (model.Type)
                {
                    case BorderType.High: return GetLowBorder(current, model.Range);
                    case BorderType.Low: return GetHighBorder(current, model.Range);
                }

                return DateTime.MinValue;
            }


            protected DateTime GetLowBorder(DateTime current, BorderRange range)
            {
                switch (range)
                {
                    case BorderRange.Day: return new DateTime(current.Year, current.Month, current.Day);
                    case BorderRange.Month: return new DateTime(current.Year, current.Month, 0);
                }
                throw new NotSupportedException("Other values are not supported");
            }

            protected DateTime GetHighBorder(DateTime current, BorderRange range)
            {
                switch (range)
                {
                    case BorderRange.Day: return new DateTime(current.Year, current.Month, current.Day + 1);
                    case BorderRange.Year: return new DateTime(current.Year + 1);
                }
                throw new NotSupportedException("Other values are not supported");
            }
        }

}
}
