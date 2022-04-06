﻿using System;
using RevendaCarro.Domain.UnitOfWork.Interface;

namespace RevendaCarro.Domain.EventHandlers.Base
{
    public class EventHandlerBase
    {
        #region Constructor
        protected readonly IUofW _uow;

        public EventHandlerBase(IUofW uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _uow?.Dispose();
                }

                // Free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
