/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. All rights reserved.
 *
 * This software is subject to the Microsoft Public License (Ms-PL). 
 * A copy of the license can be found in the license.htm file included 
 * in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

namespace System.Web.Mvc {
    using System.Collections.Generic;
    using System.Linq;

    public class FilterInfo {
        private List<IActionFilter> _actionFilters = new List<IActionFilter>();
        private List<IAuthorizationFilter> _authorizationFilters = new List<IAuthorizationFilter>();
        private List<IExceptionFilter> _exceptionFilters = new List<IExceptionFilter>();
        private List<IResultFilter> _resultFilters = new List<IResultFilter>();

        public FilterInfo() {
        }

        public FilterInfo(IEnumerable<Filter> filters) {
            // evaluate the 'filters' enumerable only once since the operation can be quite expensive
            var filterInstances = filters.Select(f => f.Instance).ToList();

            _actionFilters.AddRange(filterInstances.OfType<IActionFilter>());
            _authorizationFilters.AddRange(filterInstances.OfType<IAuthorizationFilter>());
            _exceptionFilters.AddRange(filterInstances.OfType<IExceptionFilter>());
            _resultFilters.AddRange(filterInstances.OfType<IResultFilter>());
        }

        public IList<IActionFilter> ActionFilters {
            get {
                return _actionFilters;
            }
        }

        public IList<IAuthorizationFilter> AuthorizationFilters {
            get {
                return _authorizationFilters;
            }
        }

        public IList<IExceptionFilter> ExceptionFilters {
            get {
                return _exceptionFilters;
            }
        }

        public IList<IResultFilter> ResultFilters {
            get {
                return _resultFilters;
            }
        }
    }
}
