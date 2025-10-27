using System;
using System.Linq.Expressions;
using Example04;

public static class SqlBuilder<T>
{
    public static string Where(Expression<Func<T, bool>> predicate)
    {
        var visitor = new SqlExpressionVisitor();
        var whereClause = visitor.Translate(predicate.Body);
        return $"SELECT * FROM {typeof(T).Name} WHERE {whereClause}";
    }
}
