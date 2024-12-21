using System.Collections.Generic;
using System.Diagnostics;

public class Observable<T>
{
    public delegate void OnValueChangedEventHandler(T oldValue, T newValue);
    public event OnValueChangedEventHandler? OnValueChanged;

    public Observable(T value)
    {
        m_Value = value;
    }

    T m_Value;
    public T Value
    {
        get
        {
            return m_Value;
        }
        set
        {
            if (EqualityComparer<T>.Default.Equals(value, m_Value)) return;

            T oldValue = m_Value;
            m_Value = value;
            OnValueChanged?.Invoke(oldValue, m_Value);
        }
    }
}