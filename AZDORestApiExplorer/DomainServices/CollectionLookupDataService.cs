﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using AZDORestApiExplorer.Persistence.Data;

using VNC;

using VNC.Core.DomainServices;

namespace AZDORestApiExplorer.DomainServices
{
    public class CollectionLookupDataService : ICollectionLookupDataService
    {

        #region Constructors, Initialization, and Load

        public CollectionLookupDataService(Func<AZDORestApiExplorerDbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

        #region Enums


        #endregion

        #region Structures


        #endregion

        #region Fields and Properties

        private Func<AZDORestApiExplorerDbContext> _contextCreator;

        #endregion

        #region Event Handlers


        #endregion

        #region Public Methods

        public async Task<IEnumerable<LookupItem>> GetCollectionLookupAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("(CollectionLookupDataService) Enter", Common.LOG_APPNAME);

            IEnumerable<LookupItem> result = null;

            //using (var ctx = _contextCreator())
            //{
            //    result = await ctx.CollectionsSet.AsNoTracking()
            //      .Select(f =>
            //      new LookupItem
            //      {
            //          Id = f.Id,
            //          DisplayMember = f.FieldString
            //      })
            //      .ToListAsync();
            //}

            Log.DOMAINSERVICES("(CollectionLookupDataService) Exit", Common.LOG_APPNAME, startTicks);

            return result;
        }

        #endregion

        #region Protected Methods


        #endregion

        #region Private Methods


        #endregion

    }
}