﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Journal.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Journal.Application.Resources.ErrorMessage", typeof(ErrorMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Отчёт с таким названием уже существует.
        /// </summary>
        internal static string ArticleAlreadyExists {
            get {
                return ResourceManager.GetString("ArticleAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Отчёт не найден.
        /// </summary>
        internal static string ArticleNotFound {
            get {
                return ResourceManager.GetString("ArticleNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Отчеты не найдены.
        /// </summary>
        internal static string ArticlesNotFound {
            get {
                return ResourceManager.GetString("ArticlesNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Комментарий не найден.
        /// </summary>
        internal static string CommentNotFound {
            get {
                return ResourceManager.GetString("CommentNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Коментарии не найдены.
        /// </summary>
        internal static string CommentsNotFound {
            get {
                return ResourceManager.GetString("CommentsNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Нельзя добавить больше трёх одинаковых коментариев.
        /// </summary>
        internal static string CommentsOverThanThree {
            get {
                return ResourceManager.GetString("CommentsOverThanThree", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Внутренняя ошибка сервера.
        /// </summary>
        internal static string InternalServerError {
            get {
                return ResourceManager.GetString("InternalServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Некорректный запрос.
        /// </summary>
        internal static string InvalidClientRequest {
            get {
                return ResourceManager.GetString("InvalidClientRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Невалидный токен.
        /// </summary>
        internal static string InvalidToken {
            get {
                return ResourceManager.GetString("InvalidToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Неверный пароль.
        /// </summary>
        internal static string PasswordIsWrong {
            get {
                return ResourceManager.GetString("PasswordIsWrong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пароли не совпадают.
        /// </summary>
        internal static string PasswordNotEqualPasswordConfirm {
            get {
                return ResourceManager.GetString("PasswordNotEqualPasswordConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Тэг уже добавлен.
        /// </summary>
        internal static string TagAlreadyAppends {
            get {
                return ResourceManager.GetString("TagAlreadyAppends", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Тэг с таким названием уже существует.
        /// </summary>
        internal static string TagAlreadyExists {
            get {
                return ResourceManager.GetString("TagAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Тэг не найден.
        /// </summary>
        internal static string TagNotFound {
            get {
                return ResourceManager.GetString("TagNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Тэги не найдены.
        /// </summary>
        internal static string TagsNotFound {
            get {
                return ResourceManager.GetString("TagsNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пользователь с такими данными уже существует.
        /// </summary>
        internal static string UserAlreadyExists {
            get {
                return ResourceManager.GetString("UserAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пользователь не найден.
        /// </summary>
        internal static string UserNotFound {
            get {
                return ResourceManager.GetString("UserNotFound", resourceCulture);
            }
        }
    }
}
