//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Song.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<int> AuthorId { get; set; }
    
        public virtual Author Author { get; set; }
    }
}