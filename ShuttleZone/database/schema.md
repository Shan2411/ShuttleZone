-- SQL Schema for programming languages
-- Creates the database and tables with InnoDB engine for transaction support.
-- IMPORTANT: Only changed the Users/Roles section to store simple plaintext passwords as requested.

SET NAMES utf8mb4;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET default_storage_engine = InnoDB;

-- Create and use the database
CREATE DATABASE IF NOT EXISTS `shuttlezone`;
USE `shuttlezone`;

--
-- Table structure for table `courts`
--

DROP TABLE IF EXISTS `courts`;
CREATE TABLE `courts` (
    `court_id` INT AUTO_INCREMENT PRIMARY KEY,
    `court_name` VARCHAR(50),
    `status` ENUM('Operational', 'Under Maintenance', 'Out of Service', 'In Use') DEFAULT 'Operational',
    `price_per_hour` DECIMAL(8,2) NOT NULL,
    `VAT_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `member_discount` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `status_reason` VARCHAR(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Insert 4 sample courts with different characteristics
INSERT INTO `courts` (
    `court_id`, 
    `court_name`, 
    `status`, 
    `price_per_hour`, 
    `VAT_rate`, 
    `member_discount`
) VALUES 
-- Court A:
('0121', 'Court A', 'Under Maintenance', 35.00, 15.00, 15.00),

-- Court B: 
('1022', 'Court B', 'Out Of Service', 25.00, 15.00, 10.00),

-- Court C: 
('1023', 'Court C', 'Operational', 15.00, 15.00, 5.00),

-- Court D: 
('1024', 'Court D', 'Under Maintenance', 20.00, 15.00, 10.00);

-- MEMBERSHIP
-- 

CREATE DATABASE IF NOT EXISTS shuttlezone DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE shuttlezone;

CREATE TABLE IF NOT EXISTS members (
  id INT NOT NULL AUTO_INCREMENT,
  member_code VARCHAR(16) DEFAULT NULL,
  name VARCHAR(255) DEFAULT NULL,
  email VARCHAR(255) DEFAULT NULL,
  phone VARCHAR(50) DEFAULT NULL,
  membership_type VARCHAR(100) DEFAULT NULL,
  expiry_date DATE DEFAULT NULL,
  join_date DATE DEFAULT NULL,
  is_archived TINYINT(1) NOT NULL DEFAULT 0,
  created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Simple users table (replace the previous Users/Roles section)
-- USERS   Uses a string id like 'U001' to avoid GENERATED columns/triggers and keep everything simple.
--

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
    `id` VARCHAR(10) NOT NULL PRIMARY KEY,      -- e.g. U001
    `username` VARCHAR(50) NOT NULL UNIQUE,
    `full_name` VARCHAR(100) NOT NULL,
    `email` VARCHAR(100) NOT NULL UNIQUE,
    `role` ENUM('Admin','Manager','Front Desk') NOT NULL,
    `status` ENUM('Active','Inactive') NOT NULL DEFAULT 'Active',
    `password` VARCHAR(100) NOT NULL,           -- simple plaintext as requested (testing only)
    `created_at` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Premade users
INSERT INTO `users` (`id`, `username`, `full_name`, `email`, `role`, `status`, `password`) VALUES
('U001', 'admin', 'System Administrator', 'admin@shuttlezone.local', 'Admin', 'Active', 'Admin@123'),
('U002', 'manager01', 'Manager One', 'manager1@shuttlezone.local', 'Manager', 'Active', 'Manager@123'),
('U003', 'frontdesk01', 'Front Desk One', 'frontdesk1@shuttlezone.local', 'Front Desk', 'Active', 'FrontDesk@123');

-- Quick check
-- SELECT id, username, role, status FROM users;

-- EQUIPMENT AND INVENTORY
--

-- Create equipment table for ShuttleZone (MySQL / XAMPP)
CREATE TABLE IF NOT EXISTS `equipment` (
  `Id` VARCHAR(50) NOT NULL,
  `Name` VARCHAR(255) NOT NULL,
  `Category` VARCHAR(255) NOT NULL,
  `Total` INT NOT NULL DEFAULT 0,
  `Available` INT NOT NULL DEFAULT 0,
  `Rented` INT NOT NULL DEFAULT 0,
  `Price` DECIMAL(10,2) NOT NULL DEFAULT 0.00,
  `Status` VARCHAR(50) NOT NULL DEFAULT 'Available',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Example seed data (a few rows)
INSERT INTO `equipment` (`Id`, `Name`, `Category`, `Total`, `Available`, `Rented`, `Price`, `Status`) VALUES
('EQ001', 'Yonex Racket', 'Rackets', 10, 8, 2, 150.00, 'Available'),
('EQ002', 'Shuttlecock', 'Shuttlecocks', 50, 50, 0, 25.00, 'Available'),
('EQ003', 'Badminton Net', 'Nets', 5, 5, 0, 300.00, 'Available'),
('EQ004', 'Grip Tape', 'Accessories', 40, 40, 0, 5.50, 'Available'),
('EQ005', 'Scoreboard', 'Equipment', 2, 1, 1, 1200.00, 'In Use');

-- Optional: basic index on Category and Status to speed searches
CREATE INDEX IF NOT EXISTS `idx_equipment_category` ON `equipment`(`Category`);
CREATE INDEX IF NOT EXISTS `idx_equipment_status` ON `equipment`(`Status`);
