# Creating database
DROP DATABASE IF EXISTS `ElementalMatter`;
CREATE DATABASE `ElementalMatter`;

USE `ElementalMatter`;

# Creating Elements
DROP TABLE IF EXISTS `Elements`;

CREATE TABLE `Elements` (
	`ID` INT UNSIGNED NOT NULL AUTO_INCREMENT,
	`Name` TEXT NOT NULL,
	`Symbol` TEXT NOT NULL,
	`Electrons` INT UNSIGNED NOT NULL DEFAULT 0,
	`Protons` INT UNSIGNED NOT NULL DEFAULT 0,
	`Neutrons` INT UNSIGNED NOT NULL DEFAULT 0,
	INDEX `Index 1` (`ID`)
) COLLATE='latin1_swedish_ci';

INSERT INTO `Elements` (`Name`, `Symbol`, `Electrons`, `Protons`, `Neutrons`) VALUES 
('Hydrogen', 'H', 1, 1, 0),
('Helium', 'He', 2, 2, 1),
('Lithium', 'Li', 3, 3, 3),
('Beryllium', 'Be', 4, 4, 4),
('Boron', 'B', 5, 5, 5),
('Carbon', 'C', 6, 6, 5),
('Nitrogen', 'N', 7, 7, 6),
('Oxygen', 'O', 8, 8, 7),
('Fluorine', 'F', 9, 9, 9),
('Neon', 'Ne', 10, 10, 10),
('Sodium', 'Na', 11, 11, 11),
('Magnesium', 'Mg', 12, 12, 12),
('Aluminum', 'Al', 13, 13, 13),
('Silicon', 'Si', 14, 14, 13),
('Phosphorus', 'P', 15, 15, 15),
('Sulfur', 'S', 16, 16, 15),
('Chlorine', 'Cl', 17, 17, 18),
('Argon', 'Ar', 18, 18, 19),
('Potassium', 'K', 19, 19, 21),
('Calcium', 'Ca', 20, 20, 19),
('Scandium', 'Sc', 21, 21, 23),
('Titanium', 'Ti', 22, 22, 25),
('Vanadium', 'V', 23, 23, 27),
('Chromium', 'Cr', 24, 24, 27),
('Manganese', 'Mn', 25, 25, 29),
('Iron', 'Fe', 26, 26, 29),
('Cobalt', 'Co', 27, 27, 30),
('Nickel', 'Ni', 28, 28, 31),
('Copper', 'Cu', 29, 29, 34),
('Zinc', 'Zn', 30, 30, 35),
('Gallium', 'Ga', 31, 31, 38),
('Germanium', 'Ge', 32, 32, 40),
('Arsenic', 'As', 33, 33, 41),
('Selenium', 'Se', 34, 34, 44),
('Bromine', 'Br', 35, 35, 44),
('Krypton', 'Kr', 36, 36, 47),
('Rubidium', 'Rb', 37, 37, 48),
('Strontium', 'Sr', 38, 38, 49),
('Yttrium', 'Y', 39, 39, 49),
('Zirconium', 'Zr', 40, 40, 50),
('Niobium', 'Nb', 41, 41, 51),
('Molybdenum', 'Mo', 42, 42, 53),
('Technetium', 'Tc', 43, 43, 54),
('Ruthenium', 'Ru', 44, 44, 56),
('Rhodium', 'Rh', 45, 45, 57),
('Palladium', 'Pd', 46, 46, 59),
('Silver', 'Ag', 47, 47, 60),
('Cadmium', 'Cd', 48, 48, 63),
('Indium', 'In', 49, 49, 65),
('Tin', 'Sn', 50, 50, 68),
('Antimony', 'Sb', 51, 51, 70),
('Tellurium', 'Te', 52, 52, 73),
('Iodine', 'I', 53, 53, 75),
('Xenon', 'Xe', 54, 54, 76),
('Cesium', 'Cs', 55, 55, 77),
('Barium', 'Ba', 56, 56, 80),
('Lanthanum', 'La', 57, 57, 81),
('Cerium', 'Ce', 58, 58, 81),
('Praseodymium', 'Pr', 59, 59, 81),
('Neodymium', 'Nd', 60, 60, 83),
('Promethium', 'Pm', 61, 61, 83),
('Samarium', 'Sm', 62, 62, 87),
('Europium', 'Eu', 63, 63, 88),
('Gadolinium', 'Gd', 64, 64, 92),
('Terbium', 'Tb', 65, 65, 93),
('Dysprosium', 'Dy', 66, 66, 95),
('Holmium', 'Ho', 67, 67, 97),
('Erbium', 'Er', 68, 68, 98),
('Thulium', 'Tm', 69, 69, 99),
('Ytterbium', 'Yb', 70, 70, 102),
('Lutetium', 'Lu', 71, 71, 103),
('Hafnium', 'Hf', 72, 72, 105),
('Tantalum', 'Ta', 73, 73, 107),
('Tungsten', 'W', 74, 74, 108),
('Rhenium', 'Re', 75, 75, 110),
('Osmium', 'Os', 76, 76, 113),
('Iridium', 'Ir', 77, 77, 114),
('Platinum', 'Pt', 78, 78, 116),
('Gold', 'Au', 79, 79, 117),
('Mercury', 'Hg', 80, 80, 119),
('Thallium', 'Tl', 81, 81, 122),
('Lead', 'Pb', 82, 82, 124),
('Bismuth', 'Bi', 83, 83, 124),
('Polonium', 'Po', 84, 84, 124),
('Astatine', 'At', 85, 85, 124),
('Radon', 'Rn', 86, 86, 134),
('Francium', 'Fr', 87, 87, 134),
('Radium', 'Ra', 88, 88, 136),
('Actinium', 'Ac', 89, 89, 136),
('Thorium', 'Th', 90, 90, 138),
('Protactinium', 'Pa', 91, 91, 140),
('Uranium', 'U', 92, 92, 142),
('Neptunium', 'Np', 93, 93, 144),
('Plutonium', 'Pu', 94, 94, 146),
('Americium', 'Am', 95, 95, 148),
('Curium', 'Cm', 96, 96, 149),
('Berkelium', 'Bk', 97, 97, 148),
('Californium', 'Cf', 98, 98, 151),
('Einsteinium', 'Es', 99, 99, 151),
('Fermium', 'Fm', 100, 100, 155),
('Mendelevium', 'Md', 101, 101, 155),
('Nobelium', 'No', 102, 102, 155),
('Lawrencium', 'Lr', 103, 103, 155),
('Rutherfordium', 'Rf', 104, 104, 157),
('Dubnium', 'Db', 105, 105, 155),
('Seaborgium', 'Sg', 106, 106, 155),
('Bohrium', 'Bh', 107, 107, 158),
('Hassium', 'Hs', 108, 108, 157),
('Meitnerium', 'Mt', 109, 109, 159),
('Roentgenium', 'Rg', 111, 111, 167);

# Creating UserElements
DROP TABLE IF EXISTS `UserElements`;

CREATE TABLE `UserElements` (
	`UserID` INT UNSIGNED NOT NULL,
	`ElementID` INT UNSIGNED NOT NULL
) COLLATE='latin1_swedish_ci';

# Creating Users
DROP TABLE IF EXISTS `Users`;

CREATE TABLE `Users` (
	`UserID` INT UNSIGNED NOT NULL AUTO_INCREMENT,
	`Username` TEXT NOT NULL,
#	`PasswordHash` TEXT NOT NULL,
	INDEX `Index 1` (`UserID`)
) COLLATE='latin1_swedish_ci';

# Creating Statistics
DROP TABLE IF EXISTS `Statistics`;

CREATE TABLE `Statistics` (
	`UserID` INT UNSIGNED NOT NULL,
	`AtomsCreated` INT UNSIGNED NOT NULL,
	`HoursPlayed` INT UNSIGNED NOT NULL
) COLLATE='latin1_swedish_ci';