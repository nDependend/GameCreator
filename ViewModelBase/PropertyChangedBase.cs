using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
[Serializable()]
public class PropertyChangedBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
	public bool SetProperty<T>(T value, ref T field, Expression<Func<object>> property)
	{
		return SetProperty(value, ref field, GetPropertyName(property));
	}
	public bool SetProperty<T>(T value, ref T field,[CallerMemberName()] string propertyName = null)
	{
		if (field == null || !field.Equals(value)) {
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}
		return false;
	}
	public void OnPropertyChanged([CallerMemberName()] string propertyName = null)
	{
		if (PropertyChanged != null) {
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	public void OnPropertyChanged(Expression<Func<object>> property)
	{
		OnPropertyChanged(GetPropertyName(property));
	}
	public string GetPropertyName(Expression<Func<object>> property)
	{
		dynamic lambda = property as LambdaExpression;
		MemberExpression memberExpression = default(MemberExpression);
		if (lambda.Body is UnaryExpression) {
			dynamic unaryExpression = lambda.Body as UnaryExpression;
			memberExpression = unaryExpression.Operand as MemberExpression;
		} else {
			memberExpression = lambda.Body as MemberExpression;
		}
		if (memberExpression != null) {
			dynamic constantExpression = memberExpression.Expression as ConstantExpression;
			dynamic propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo != null) {
				return propertyInfo.Name;
			}
		}
		return String.Empty;
	}
}
