/*
Author          : Sr Programmer Analyst Oleg Gorlov
Description:	: Generic class collection IQueryable, IEnumerable<T> to check DataContext. 
                : Copyright  GMedia-IT-Consulting, Smart Systems 
email           : oleg_gorlov@yahoo.com
Date            : 05/05/2017
Release         : 1.0.0
Comment         : 

 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;


namespace SmartSystemsDBContextTest
{
    [TestClass]
    class TestDbSet<T> :  IQueryable, IEnumerable<T>
            where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }


        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}
