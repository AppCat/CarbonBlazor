﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonBlazor
{
    /// <summary>
    /// 组件配置
    /// </summary>
    public class BxComponentConfig : IBxComponentConfig
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; private set; }

        /// <summary>
        /// 类
        /// </summary>
        public string? Class
        {
            get => _class;
            set
            {
                if(value != null && value != _class)
                {
                    _class = value;
                    ClassMapper.Original = value;
                }
            }
        }
        private string? _class;

        /// <summary>
        /// 类映射器
        /// </summary>
        public ClassMapper ClassMapper { get; set; } = new ClassMapper();

        /// <summary>
        /// 类
        /// </summary>
        internal string AsClass { get => $"{ClassMapper.Result}{(!string.IsNullOrEmpty(Class) ? $" {Class}" : "")}"; }

        /// <summary>
        /// 样式
        /// </summary>
        public string? Style
        {
            get => _style;
            set
            {
                if (value != null && value != _style)
                {
                    _style = value;
                    StyleMapper.Original = value;
                }
            }
        }
        private string? _style;

        /// <summary>
        /// 样式映射器
        /// </summary>
        public StyleMapper StyleMapper { get; set; } = new StyleMapper();

        /// <summary>
        /// 样式
        /// </summary>
        internal string AsStyle { get => $"{StyleMapper.Result}{(!string.IsNullOrEmpty(Style) ? $" {Style}" : "")}"; }

        /// <summary>
        /// 属性
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 组件配置
        /// </summary>
        public BxComponentConfig()
        {

        }

        /// <summary>
        /// 组件配置
        /// </summary>
        public BxComponentConfig(IBxComponentConfig? config)
        {
            if (config != null)
            {
                if (config is BxComponentConfig bcc)
                {
                    Style = bcc.AsStyle;
                    Class = bcc.AsClass;
                }
                else
                {
                    Style = config.Style;
                    Class = config.Class;
                }
                Attributes = config.Attributes ?? new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// 组件配置
        /// </summary>
        public BxComponentConfig(IBxComponentConfig? config, string fixedClass, string id)
        {
            if (config != null)
            {
                if(config is BxComponentConfig bcc)
                {
                    Style = bcc.AsStyle;
                    Class = bcc.AsClass;
                }
                else
                {
                    Style = config.Style;
                    Class = config.Class;
                }
                Attributes = config.Attributes ?? new Dictionary<string, object>();
            }

            AddClass(fixedClass);
            SetId(id);
        }

        /// <summary>
        /// 组件配置
        /// </summary>
        public BxComponentConfig(string fixedClass, string id)
        {
            AddClass(fixedClass);
            SetId(id);
        }

        /// <summary>
        /// Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BxComponentConfig SetId(string id)
        {
            Id = id;
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="cover"></param>
        /// <returns></returns>
        public BxComponentConfig AddStyle(string name, string value, bool cover = true)
        {
            if (cover)
            {
                StyleMapper.AddGetOrUpdateIf(name, () => value, () => true);
            }
            else
            {
                StyleMapper.AddGet(name, () => value);
            }
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="cover"></param>
        /// <returns></returns>
        public BxComponentConfig AddStyle(string name, Func<string> value, bool cover = true)
        {
            if (cover)
            {
                StyleMapper.AddGetOrUpdateIf(name, value, () => true);
            }
            else
            {
                StyleMapper.AddGet(name, value);
            }
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="allow"></param>
        /// <param name="cover"></param>
        /// <returns></returns>
        public BxComponentConfig AddIfStyle(string name, string value, Func<bool> allow, bool cover = true)
        {
            if (cover)
            {
                StyleMapper.AddGetOrUpdateIf(name, () => value, allow);
            }
            else
            {
                StyleMapper.AddIf(name, value, allow);
            }
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="allow"></param>
        /// <param name="cover"></param>
        /// <returns></returns>
        public BxComponentConfig AddIfStyle(string name, Func<string> value, Func<bool> allow, bool cover = true)
        {
            if (cover)
            {
                StyleMapper.AddGetOrUpdateIf(name, value, allow);
            }
            else
            {
                StyleMapper.AddGetIf(name, value, allow);
            }
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public BxComponentConfig AddClass(string @class)
        {
            ClassMapper.Add(@class);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public BxComponentConfig AddClass(Func<string> @class)
        {
            ClassMapper.Get(@class);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public BxComponentConfig AddIfClass(string @class, Func<bool> ifFunc)
        {
            ClassMapper.If(@class, ifFunc);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public BxComponentConfig AddIfClass(Func<string> @class, Func<bool> ifFunc)
        {
            ClassMapper.GetIf(@class, ifFunc);
            return this;
        }
    }
}
