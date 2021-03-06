﻿// This file is part of RosettaCTF project.
//
// Copyright 2020 Emzi0767
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using RosettaCTF.Models;

namespace RosettaCTF.SeedData
{
    internal static class CountrySeedData
    {
        public static IEnumerable<PostgresCountry> SeedCountries { get; } = new[]
        {
            new PostgresCountry { Code = "af", Name = "Afghanistan" },
            new PostgresCountry { Code = "ax", Name = "Åland Islands" },
            new PostgresCountry { Code = "al", Name = "Albania" },
            new PostgresCountry { Code = "dz", Name = "Algeria" },
            new PostgresCountry { Code = "as", Name = "American Samoa" },
            new PostgresCountry { Code = "ad", Name = "Andorra" },
            new PostgresCountry { Code = "ao", Name = "Angola" },
            new PostgresCountry { Code = "ai", Name = "Anguilla" },
            new PostgresCountry { Code = "aq", Name = "Antarctica" },
            new PostgresCountry { Code = "ag", Name = "Antigua and Barbuda" },
            new PostgresCountry { Code = "ar", Name = "Argentina" },
            new PostgresCountry { Code = "am", Name = "Armenia" },
            new PostgresCountry { Code = "aw", Name = "Aruba" },
            new PostgresCountry { Code = "au", Name = "Australia" },
            new PostgresCountry { Code = "at", Name = "Austria" },
            new PostgresCountry { Code = "az", Name = "Azerbaijan" },
            new PostgresCountry { Code = "bs", Name = "Bahamas" },
            new PostgresCountry { Code = "bh", Name = "Bahrain" },
            new PostgresCountry { Code = "bd", Name = "Bangladesh" },
            new PostgresCountry { Code = "bb", Name = "Barbados" },
            new PostgresCountry { Code = "by", Name = "Belarus" },
            new PostgresCountry { Code = "be", Name = "Belgium" },
            new PostgresCountry { Code = "bz", Name = "Belize" },
            new PostgresCountry { Code = "bj", Name = "Benin" },
            new PostgresCountry { Code = "bm", Name = "Bermuda" },
            new PostgresCountry { Code = "bt", Name = "Bhutan" },
            new PostgresCountry { Code = "bo", Name = "Bolivia (Plurinational State of)" },
            new PostgresCountry { Code = "bq", Name = "Bonaire, Sint Eustatius and Saba" },
            new PostgresCountry { Code = "ba", Name = "Bosnia and Herzegovina" },
            new PostgresCountry { Code = "bw", Name = "Botswana" },
            new PostgresCountry { Code = "bv", Name = "Bouvet Island" },
            new PostgresCountry { Code = "br", Name = "Brazil" },
            new PostgresCountry { Code = "io", Name = "British Indian Ocean Territory" },
            new PostgresCountry { Code = "bn", Name = "Brunei Darussalam" },
            new PostgresCountry { Code = "bg", Name = "Bulgaria" },
            new PostgresCountry { Code = "bf", Name = "Burkina Faso" },
            new PostgresCountry { Code = "bi", Name = "Burundi" },
            new PostgresCountry { Code = "cv", Name = "Cabo Verde" },
            new PostgresCountry { Code = "kh", Name = "Cambodia" },
            new PostgresCountry { Code = "cm", Name = "Cameroon" },
            new PostgresCountry { Code = "ca", Name = "Canada" },
            new PostgresCountry { Code = "ky", Name = "Cayman Islands" },
            new PostgresCountry { Code = "cf", Name = "Central African Republic" },
            new PostgresCountry { Code = "td", Name = "Chad" },
            new PostgresCountry { Code = "cl", Name = "Chile" },
            new PostgresCountry { Code = "cn", Name = "China" },
            new PostgresCountry { Code = "cx", Name = "Christmas Island" },
            new PostgresCountry { Code = "cc", Name = "Cocos (Keeling) Islands" },
            new PostgresCountry { Code = "co", Name = "Colombia" },
            new PostgresCountry { Code = "km", Name = "Comoros" },
            new PostgresCountry { Code = "cg", Name = "Congo" },
            new PostgresCountry { Code = "cd", Name = "Congo, Democratic Republic of the" },
            new PostgresCountry { Code = "ck", Name = "Cook Islands" },
            new PostgresCountry { Code = "cr", Name = "Costa Rica" },
            new PostgresCountry { Code = "ci", Name = "Côte d'Ivoire" },
            new PostgresCountry { Code = "hr", Name = "Croatia" },
            new PostgresCountry { Code = "cu", Name = "Cuba" },
            new PostgresCountry { Code = "cw", Name = "Curaçao" },
            new PostgresCountry { Code = "cy", Name = "Cyprus" },
            new PostgresCountry { Code = "cz", Name = "Czechia" },
            new PostgresCountry { Code = "dk", Name = "Denmark" },
            new PostgresCountry { Code = "dj", Name = "Djibouti" },
            new PostgresCountry { Code = "dm", Name = "Dominica" },
            new PostgresCountry { Code = "do", Name = "Dominican Republic" },
            new PostgresCountry { Code = "ec", Name = "Ecuador" },
            new PostgresCountry { Code = "eg", Name = "Egypt" },
            new PostgresCountry { Code = "sv", Name = "El Salvador" },
            new PostgresCountry { Code = "gq", Name = "Equatorial Guinea" },
            new PostgresCountry { Code = "er", Name = "Eritrea" },
            new PostgresCountry { Code = "ee", Name = "Estonia" },
            new PostgresCountry { Code = "sz", Name = "Eswatini" },
            new PostgresCountry { Code = "et", Name = "Ethiopia" },
            new PostgresCountry { Code = "fk", Name = "Falkland Islands (Malvinas)" },
            new PostgresCountry { Code = "fo", Name = "Faroe Islands" },
            new PostgresCountry { Code = "fj", Name = "Fiji" },
            new PostgresCountry { Code = "fi", Name = "Finland" },
            new PostgresCountry { Code = "fr", Name = "France" },
            new PostgresCountry { Code = "gf", Name = "French Guiana" },
            new PostgresCountry { Code = "pf", Name = "French Polynesia" },
            new PostgresCountry { Code = "tf", Name = "French Southern Territories" },
            new PostgresCountry { Code = "ga", Name = "Gabon" },
            new PostgresCountry { Code = "gm", Name = "Gambia" },
            new PostgresCountry { Code = "ge", Name = "Georgia" },
            new PostgresCountry { Code = "de", Name = "Germany" },
            new PostgresCountry { Code = "gh", Name = "Ghana" },
            new PostgresCountry { Code = "gi", Name = "Gibraltar" },
            new PostgresCountry { Code = "gr", Name = "Greece" },
            new PostgresCountry { Code = "gl", Name = "Greenland" },
            new PostgresCountry { Code = "gd", Name = "Grenada" },
            new PostgresCountry { Code = "gp", Name = "Guadeloupe" },
            new PostgresCountry { Code = "gu", Name = "Guam" },
            new PostgresCountry { Code = "gt", Name = "Guatemala" },
            new PostgresCountry { Code = "gg", Name = "Guernsey" },
            new PostgresCountry { Code = "gn", Name = "Guinea" },
            new PostgresCountry { Code = "gw", Name = "Guinea-Bissau" },
            new PostgresCountry { Code = "gy", Name = "Guyana" },
            new PostgresCountry { Code = "ht", Name = "Haiti" },
            new PostgresCountry { Code = "hm", Name = "Heard Island and McDonald Islands" },
            new PostgresCountry { Code = "va", Name = "Holy See" },
            new PostgresCountry { Code = "hn", Name = "Honduras" },
            new PostgresCountry { Code = "hk", Name = "Hong Kong" },
            new PostgresCountry { Code = "hu", Name = "Hungary" },
            new PostgresCountry { Code = "is", Name = "Iceland" },
            new PostgresCountry { Code = "in", Name = "India" },
            new PostgresCountry { Code = "id", Name = "Indonesia" },
            new PostgresCountry { Code = "ir", Name = "Iran (Islamic Republic of)" },
            new PostgresCountry { Code = "iq", Name = "Iraq" },
            new PostgresCountry { Code = "ie", Name = "Ireland" },
            new PostgresCountry { Code = "im", Name = "Isle of Man" },
            new PostgresCountry { Code = "il", Name = "Israel" },
            new PostgresCountry { Code = "it", Name = "Italy" },
            new PostgresCountry { Code = "jm", Name = "Jamaica" },
            new PostgresCountry { Code = "jp", Name = "Japan" },
            new PostgresCountry { Code = "je", Name = "Jersey" },
            new PostgresCountry { Code = "jo", Name = "Jordan" },
            new PostgresCountry { Code = "kz", Name = "Kazakhstan" },
            new PostgresCountry { Code = "ke", Name = "Kenya" },
            new PostgresCountry { Code = "ki", Name = "Kiribati" },
            new PostgresCountry { Code = "kp", Name = "Korea (Democratic People's Republic of)" },
            new PostgresCountry { Code = "kr", Name = "Korea, Republic of" },
            new PostgresCountry { Code = "kw", Name = "Kuwait" },
            new PostgresCountry { Code = "kg", Name = "Kyrgyzstan" },
            new PostgresCountry { Code = "la", Name = "Lao People's Democratic Republic" },
            new PostgresCountry { Code = "lv", Name = "Latvia" },
            new PostgresCountry { Code = "lb", Name = "Lebanon" },
            new PostgresCountry { Code = "ls", Name = "Lesotho" },
            new PostgresCountry { Code = "lr", Name = "Liberia" },
            new PostgresCountry { Code = "ly", Name = "Libya" },
            new PostgresCountry { Code = "li", Name = "Liechtenstein" },
            new PostgresCountry { Code = "lt", Name = "Lithuania" },
            new PostgresCountry { Code = "lu", Name = "Luxembourg" },
            new PostgresCountry { Code = "mo", Name = "Macao" },
            new PostgresCountry { Code = "mg", Name = "Madagascar" },
            new PostgresCountry { Code = "mw", Name = "Malawi" },
            new PostgresCountry { Code = "my", Name = "Malaysia" },
            new PostgresCountry { Code = "mv", Name = "Maldives" },
            new PostgresCountry { Code = "ml", Name = "Mali" },
            new PostgresCountry { Code = "mt", Name = "Malta" },
            new PostgresCountry { Code = "mh", Name = "Marshall Islands" },
            new PostgresCountry { Code = "mq", Name = "Martinique" },
            new PostgresCountry { Code = "mr", Name = "Mauritania" },
            new PostgresCountry { Code = "mu", Name = "Mauritius" },
            new PostgresCountry { Code = "yt", Name = "Mayotte" },
            new PostgresCountry { Code = "mx", Name = "Mexico" },
            new PostgresCountry { Code = "fm", Name = "Micronesia (Federated States of)" },
            new PostgresCountry { Code = "md", Name = "Moldova, Republic of" },
            new PostgresCountry { Code = "mc", Name = "Monaco" },
            new PostgresCountry { Code = "mn", Name = "Mongolia" },
            new PostgresCountry { Code = "me", Name = "Montenegro" },
            new PostgresCountry { Code = "ms", Name = "Montserrat" },
            new PostgresCountry { Code = "ma", Name = "Morocco" },
            new PostgresCountry { Code = "mz", Name = "Mozambique" },
            new PostgresCountry { Code = "mm", Name = "Myanmar" },
            new PostgresCountry { Code = "na", Name = "Namibia" },
            new PostgresCountry { Code = "nr", Name = "Nauru" },
            new PostgresCountry { Code = "np", Name = "Nepal" },
            new PostgresCountry { Code = "nl", Name = "Netherlands" },
            new PostgresCountry { Code = "nc", Name = "New Caledonia" },
            new PostgresCountry { Code = "nz", Name = "New Zealand" },
            new PostgresCountry { Code = "ni", Name = "Nicaragua" },
            new PostgresCountry { Code = "ne", Name = "Niger" },
            new PostgresCountry { Code = "ng", Name = "Nigeria" },
            new PostgresCountry { Code = "nu", Name = "Niue" },
            new PostgresCountry { Code = "nf", Name = "Norfolk Island" },
            new PostgresCountry { Code = "mk", Name = "North Macedonia" },
            new PostgresCountry { Code = "mp", Name = "Northern Mariana Islands" },
            new PostgresCountry { Code = "no", Name = "Norway" },
            new PostgresCountry { Code = "om", Name = "Oman" },
            new PostgresCountry { Code = "pk", Name = "Pakistan" },
            new PostgresCountry { Code = "pw", Name = "Palau" },
            new PostgresCountry { Code = "ps", Name = "Palestine, State of" },
            new PostgresCountry { Code = "pa", Name = "Panama" },
            new PostgresCountry { Code = "pg", Name = "Papua New Guinea" },
            new PostgresCountry { Code = "py", Name = "Paraguay" },
            new PostgresCountry { Code = "pe", Name = "Peru" },
            new PostgresCountry { Code = "ph", Name = "Philippines" },
            new PostgresCountry { Code = "pn", Name = "Pitcairn" },
            new PostgresCountry { Code = "pl", Name = "Poland" },
            new PostgresCountry { Code = "pt", Name = "Portugal" },
            new PostgresCountry { Code = "pr", Name = "Puerto Rico" },
            new PostgresCountry { Code = "qa", Name = "Qatar" },
            new PostgresCountry { Code = "re", Name = "Réunion" },
            new PostgresCountry { Code = "ro", Name = "Romania" },
            new PostgresCountry { Code = "ru", Name = "Russian Federation" },
            new PostgresCountry { Code = "rw", Name = "Rwanda" },
            new PostgresCountry { Code = "bl", Name = "Saint Barthélemy" },
            new PostgresCountry { Code = "sh", Name = "Saint Helena, Ascension and Tristan da Cunha" },
            new PostgresCountry { Code = "kn", Name = "Saint Kitts and Nevis" },
            new PostgresCountry { Code = "lc", Name = "Saint Lucia" },
            new PostgresCountry { Code = "mf", Name = "Saint Martin (French part)" },
            new PostgresCountry { Code = "pm", Name = "Saint Pierre and Miquelon" },
            new PostgresCountry { Code = "vc", Name = "Saint Vincent and the Grenadines" },
            new PostgresCountry { Code = "ws", Name = "Samoa" },
            new PostgresCountry { Code = "sm", Name = "San Marino" },
            new PostgresCountry { Code = "st", Name = "Sao Tome and Principe" },
            new PostgresCountry { Code = "sa", Name = "Saudi Arabia" },
            new PostgresCountry { Code = "sn", Name = "Senegal" },
            new PostgresCountry { Code = "rs", Name = "Serbia" },
            new PostgresCountry { Code = "sc", Name = "Seychelles" },
            new PostgresCountry { Code = "sl", Name = "Sierra Leone" },
            new PostgresCountry { Code = "sg", Name = "Singapore" },
            new PostgresCountry { Code = "sx", Name = "Sint Maarten (Dutch part)" },
            new PostgresCountry { Code = "sk", Name = "Slovakia" },
            new PostgresCountry { Code = "si", Name = "Slovenia" },
            new PostgresCountry { Code = "sb", Name = "Solomon Islands" },
            new PostgresCountry { Code = "so", Name = "Somalia" },
            new PostgresCountry { Code = "za", Name = "South Africa" },
            new PostgresCountry { Code = "gs", Name = "South Georgia and the South Sandwich Islands" },
            new PostgresCountry { Code = "ss", Name = "South Sudan" },
            new PostgresCountry { Code = "es", Name = "Spain" },
            new PostgresCountry { Code = "lk", Name = "Sri Lanka" },
            new PostgresCountry { Code = "sd", Name = "Sudan" },
            new PostgresCountry { Code = "sr", Name = "Suriname" },
            new PostgresCountry { Code = "sj", Name = "Svalbard and Jan Mayen" },
            new PostgresCountry { Code = "se", Name = "Sweden" },
            new PostgresCountry { Code = "ch", Name = "Switzerland" },
            new PostgresCountry { Code = "sy", Name = "Syrian Arab Republic" },
            new PostgresCountry { Code = "tw", Name = "Taiwan" },
            new PostgresCountry { Code = "tj", Name = "Tajikistan" },
            new PostgresCountry { Code = "tz", Name = "Tanzania, United Republic of" },
            new PostgresCountry { Code = "th", Name = "Thailand" },
            new PostgresCountry { Code = "tl", Name = "Timor-Leste" },
            new PostgresCountry { Code = "tg", Name = "Togo" },
            new PostgresCountry { Code = "tk", Name = "Tokelau" },
            new PostgresCountry { Code = "to", Name = "Tonga" },
            new PostgresCountry { Code = "tt", Name = "Trinidad and Tobago" },
            new PostgresCountry { Code = "tn", Name = "Tunisia" },
            new PostgresCountry { Code = "tr", Name = "Turkey" },
            new PostgresCountry { Code = "tm", Name = "Turkmenistan" },
            new PostgresCountry { Code = "tc", Name = "Turks and Caicos Islands" },
            new PostgresCountry { Code = "tv", Name = "Tuvalu" },
            new PostgresCountry { Code = "ug", Name = "Uganda" },
            new PostgresCountry { Code = "ua", Name = "Ukraine" },
            new PostgresCountry { Code = "ae", Name = "United Arab Emirates" },
            new PostgresCountry { Code = "gb", Name = "United Kingdom of Great Britain and Northern Ireland" },
            new PostgresCountry { Code = "us", Name = "United States of America" },
            new PostgresCountry { Code = "um", Name = "United States Minor Outlying Islands" },
            new PostgresCountry { Code = "uy", Name = "Uruguay" },
            new PostgresCountry { Code = "uz", Name = "Uzbekistan" },
            new PostgresCountry { Code = "vu", Name = "Vanuatu" },
            new PostgresCountry { Code = "ve", Name = "Venezuela (Bolivarian Republic of)" },
            new PostgresCountry { Code = "vn", Name = "Viet Nam" },
            new PostgresCountry { Code = "vg", Name = "Virgin Islands (British)" },
            new PostgresCountry { Code = "vi", Name = "Virgin Islands (U.S.)" },
            new PostgresCountry { Code = "wf", Name = "Wallis and Futuna" },
            new PostgresCountry { Code = "eh", Name = "Western Sahara" },
            new PostgresCountry { Code = "ye", Name = "Yemen" },
            new PostgresCountry { Code = "zm", Name = "Zambia" },
            new PostgresCountry { Code = "zw", Name = "Zimbabwe" }
        };
    }
}
