using Huān.Randoms;
using System;
using System.ComponentModel;

namespace CarbonBlazor.Demo.Models
{
    /// <summary>
    /// 人 
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Id
        /// </summary>
        [DisplayName("身份证")]
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [DisplayName("年龄")]
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public PersonSex Sex { get; set; }

        /// <summary>
        /// 是否为少先队员
        /// </summary>
        [DisplayName("是否为少先队员")]
        public bool IsYoungPioneer { get; set; }

        /// <summary>
        /// 随机创建
        /// </summary>
        /// <param name="sex"></param>
        /// <param name="minAge"></param>
        /// <param name="maxAge"></param>
        /// <returns></returns>
        public static Person RandomCreate(PersonSex? sex = null, int? minAge = null, int? maxAge = null)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            sex ??= (PersonSex)random.Next(0, 2);
            minAge ??= 10;
            maxAge ??= 30;
            var age = random.Next((int)minAge, (int)maxAge);
            var name = string.Empty;
            if (sex == PersonSex.Man)
            {
                name = RandomName.NextManName(random);
            }
            else if(sex == PersonSex.Woman)
            {
                name = RandomName.NextWoManName(random);
            }

            return new Person
            {
                Name = name,
                Age = age,
                Sex = (PersonSex)sex,
                Id = Guid.NewGuid()
            };
        }

        /// <summary>
        /// 转字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name: {Name} - Age: {Age} - Sex: {(Sex == PersonSex.Man ? "男" : "女")}";
        }
    }
}
