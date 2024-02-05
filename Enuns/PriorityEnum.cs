using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Enuns
{
    public enum PriorityEnum
    {
        [ValueAttributeCollor(0, "#FF0000","Baixa")]
        BAIXA,
        [ValueAttributeCollor(1, "#FFFF00", "Média")]
        MEDIA,
        [ValueAttributeCollor(2, "#00FF00", "Alta")]
        ALTA,
    }

    public class ValueAttributeCollor : Attribute
    {
        public int Value { get; private set; }
        public string Label { get; private set; }
        public string Color { get; private set; }

        public ValueAttributeCollor(int valor, string corHex, string label)
        {
            Value = valor;
            Color = corHex;
            Label = label;
        }
    }

    public static class PriorityEnumExtensions
    {
        public static int GetValue(this PriorityEnum priority)
        {
            var memberInfo = typeof(PriorityEnum).GetMember(priority.ToString());
            var attribute = (ValueAttributeCollor)memberInfo[0].GetCustomAttribute(typeof(ValueAttributeCollor), false);
            return attribute.Value;
        }

        public static string GetColor(this PriorityEnum priority)
        {
            var memberInfo = typeof(PriorityEnum).GetMember(priority.ToString());
            var attribute = (ValueAttributeCollor)memberInfo[0].GetCustomAttribute(typeof(ValueAttributeCollor), false);
            return attribute.Color;
        }

        public static string GetLabel(this PriorityEnum priority)
        {
            var memberInfo = typeof(PriorityEnum).GetMember(priority.ToString());
            var attribute = (ValueAttributeCollor)memberInfo[0].GetCustomAttribute(typeof(ValueAttributeCollor), false);
            return attribute.Label;
        }
    }
}
