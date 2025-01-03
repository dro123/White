using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace TestStack.White.ScreenObjects
{
    [Serializable]
    public class AppScreenException : Exception
    {
        public AppScreenException(string message) : base(message) { }
        public AppScreenException(string message, Exception exception) : base(message, exception) { }
        protected AppScreenException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public static AppScreenException NonVirtualMethods(IEnumerable<MethodInfo> methodInfos)
        {
            var messageBuilder = new StringBuilder();
            foreach (var entity in methodInfos)
            {
                string message = string.Format("{0} method in class {1} is not virtual", entity.Name, entity.DeclaringType.Name);
                messageBuilder.AppendLine(message);
            }

            return new AppScreenException(messageBuilder.ToString());
        }
    }
}