
-- SQL Schema for programming languages
-- Creates the database and tables with InnoDB engine for transaction support.

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
    `location` VARCHAR(100),
    `status` ENUM('available', 'maintenance', 'closed') DEFAULT 'available',
    `price_per_hour` DECIMAL(8,2) NOT NULL,
    `VAT_rate` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    `member_discount` DECIMAL(5,2) NOT NULL DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Insert 4 sample courts with different characteristics
INSERT INTO `courts` (
    `court_id`, 
    `court_name`, 
    `location`, 
    `status`, 
    `price_per_hour`, 
    `VAT_rate`, 
    `member_discount`
) VALUES 
-- Court A: Premium indoor court
('123', 'Court A', 'Main Hall - North Wing', 'available', 35.00, 15.00, 15.00),

-- Court B: Standard indoor court  
('1234', 'Court B', 'Main Hall - South Wing', 'available', 25.00, 15.00, 10.00),

-- Court C: Outdoor court (cheaper)
('12345', 'Court C', 'Outdoor Area', 'available', 15.00, 15.00, 5.00),

-- Court D: Court under maintenance
('123456', 'Court D', 'Annex Building', 'maintenance', 20.00, 15.00, 10.00);