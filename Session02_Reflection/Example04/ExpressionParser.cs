namespace Example04;

using System;
using System.Linq.Expressions;
using System.Text;

public class SqlExpressionVisitor : ExpressionVisitor
{
    private readonly StringBuilder _sb = new();

    public string Translate(Expression exp)
    {
        Visit(exp);
        return _sb.ToString();
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        _sb.Append("(");
        Visit(node.Left);

        switch (node.NodeType)
        {
            case ExpressionType.Equal:
                _sb.Append(" = ");
                break;
            case ExpressionType.NotEqual:
                _sb.Append(" <> ");
                break;
            case ExpressionType.GreaterThan:
                _sb.Append(" > ");
                break;
            case ExpressionType.GreaterThanOrEqual:
                _sb.Append(" >= ");
                break;
            case ExpressionType.LessThan:
                _sb.Append(" < ");
                break;
            case ExpressionType.LessThanOrEqual:
                _sb.Append(" <= ");
                break;
            case ExpressionType.AndAlso:
                _sb.Append(" AND ");
                break;
            case ExpressionType.OrElse:
                _sb.Append(" OR ");
                break;
            default:
                throw new NotSupportedException($"Unsupported node type: {node.NodeType}");
        }

        Visit(node.Right);
        _sb.Append(")");
        return node;
    }

    protected override Expression VisitMember(MemberExpression node)
    { 
        // 
        // Handle property like x.Name
        //
        _sb.Append(node.Member.Name);
        return node;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        if (node.Type == typeof(string) || node.Type == typeof(DateTime))
            _sb.Append($"'{node.Value}'");
        else
            _sb.Append(node.Value);
        return node;
    }
}

