using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace Persons.Models {
    public class PersonContextInitializer: CreateDatabaseIfNotExists<PersonsEntities> {
        public PersonContextInitializer() {
            PersonsEntities context = new PersonsEntities();

            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Persons");

            // Seed the initial data
            var employees = new List<Person> {
                new Person {
                    PersonNames = "Betty Deverou",
                    Address = "123 Main St., Atlanta, GA 30303",
                    DOB = new DateTime(1998, 03, 21),
                    Interests = "Biking, Swimming, Travel",
                    Photo = getFile(@"\Content\images\Betty.jpg")
                },
                new Person {
                    PersonNames = "Debbie Ferguson",
                    Address = "404 Tulip Sq, Atlanta, GA 41232",
                    DOB = new DateTime(1987, 05, 11),
                    Interests = "Yoga, Running, Volunteer",
                    Photo = getFile(@"\Content\images\Debbie.jpg")
                },
                new Person {
                    PersonNames = "Frank Beringer",
                    Address = "11 Lavender Ave, Atlanta, GA 81324",
                    DOB = new DateTime(1984, 01, 22),
                    Interests = "Golfing, Travelling, Fishing",
                    Photo = getFile(@"\Content\images\Frank.jpg")
                },
                new Person {
                    PersonNames = "Heather Frazier",
                    Address = "121 Juniper St, Atlanta, GA 32412",
                    DOB = new DateTime(1981, 05, 1),
                    Interests = "Pilates, Art, Reading",
                    Photo = getFile(@"\Content\images\Heather.jpg")
                },
                new Person {
                    PersonNames = "Jasmine Patel",
                    Address = "341 Magnolia Sq, Atlanta, GA 67539",
                    DOB = new DateTime(1991, 08, 22),
                    Interests = "Samba, Latin Pop Music",
                    Photo = getFile(@"\Content\images\Jasmine.jpg")
                },
                new Person {
                    PersonNames = "Jason Rinder",
                    Address = "73 Rosemary St, Atlanta, GA 75432",
                    DOB = new DateTime(1993, 04, 20),
                    Interests = "Baseball, Voleyball, Tennis",
                    Photo = getFile(@"\Content\images\Jason.jpg")
                },
                new Person {
                    PersonNames = "Leonard Trell",
                    Address = "1499 Oak St, Atlanta, GA 75432",
                    DOB = new DateTime(1965, 01, 13),
                    Interests = "Jazz, Dinning Out, Books",
                    Photo = getFile(@"\Content\images\Leonard.jpg")
                },
                new Person {
                    PersonNames = "Nancy Kirk",
                    Address = "455 Dogwood Rd, Atlanta, GA 64350",
                    DOB = new DateTime(1995, 10, 11),
                    Interests = "Sailing, Wine, Blogging",
                    Photo = getFile(@"\Content\images\Nancy.jpg")
                },
                new Person {
                    PersonNames = "Stephanie James",
                    Address = "999 Peachtree St, Atlanta, GA 11342",
                    DOB = new DateTime(1993, 07, 29),
                    Interests = "Theatre, Musicals, Art, Books",
                    Photo = getFile(@"\Content\images\Stephanie.jpg")
                }
            };

            employees.ForEach(s => context.Persons.Add(s));
            context.SaveChanges();
        }
        
        private byte[] getFile(string path) {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk)) {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}