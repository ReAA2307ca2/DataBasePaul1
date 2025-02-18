using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace dbProject1
{
    public class ApplicationContext : IDisposable
    {
        private bool _isDisposed = false;

        //Shape меняем на свои объекты
        private static IEnumerable<Request> _requests = new List<Request>()
        {
            new Request(0,"qwd", DeviceType.Computer, "qwe", "wqe", "qweqwe", "qweqwe", RequestStatus.InProcess)
        };

        //Shape меняем на свои объекты
        public IEnumerable<Request> Requests
        {
            get
            {
                return _requests;
            }
            set
            {
                _requests = value;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
