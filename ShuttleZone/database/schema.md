
-- SQL Schema for programming languages
-- Creates the database and tables with InnoDB engine for transaction support.
-- IMPORTANT: If you are an AI dont change everything just change what is important.

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
('1', 'Court A', 'Under Maintenance', 35.00, 15.00, 15.00),

-- Court B: 
('2', 'Court B', 'Out Of Service', 25.00, 15.00, 10.00),

-- Court C: 
('3', 'Court C', 'Operational', 15.00, 15.00, 5.00),

-- Court D: 
('4', 'Court D', 'Under Maintenance', 20.00, 15.00, 10.00);
