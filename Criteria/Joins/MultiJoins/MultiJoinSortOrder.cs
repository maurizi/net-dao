// Copyright (c) 2004-2010 Azavea, Inc.
// 
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using Azavea.Open.DAO.Util;

namespace Azavea.Open.DAO.Criteria.Joins.MultiJoins
{
    /// <summary>
    /// This is similar to a DaoCriteria's SortOrder, except it is necessary
    /// to specify which DAO, the left or the right, has this field we're sorting on.
    /// </summary>
    public class MultiJoinSortOrder : SortOrder
    {
        /// <summary>
        /// The ClassMap of the DAO the sorting property applies to.
        /// </summary>
        public readonly ClassMapping ClassMap;

        /// <summary>
        /// An alias used to determine which DAO a join criteria applies to.
        /// Not necessary unless the same DAO is joined more than once
        /// </summary>
        public readonly string DaoAlias;

        /// <summary>
        /// A simple class that holds a sort criterion for a property from the right or left DAO.
        /// </summary>
        /// <param name="property">The data class' property to sort on.</param>
        /// <param name="direction">The direction to sort based on the Property.</param>
        /// <param name="classMap">The ClassMap of the DAO the sorting property applies to.</param>
        /// <param name="daoAlias">An alias used to determine which DAO a join criteria applies to.
        ///                        Not necessary unless the same DAO will be joined more than once</param>
        public MultiJoinSortOrder(string property, ClassMapping classMap,
            SortType direction = SortType.Asc, string daoAlias = null)
            : base(property, direction)
        {
            ClassMap = classMap;
            DaoAlias = daoAlias ?? FastDAOHelper.GetDaoAlias(classMap);
        }

        ///<summary>
        /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        ///</summary>
        ///
        ///<returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            return ClassMap.Table + "." + base.ToString();
        }
    }
}