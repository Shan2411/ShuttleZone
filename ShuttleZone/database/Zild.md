-- =========================
-- INITIAL SETUP
-- =========================
SET NAMES utf8mb4;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET default_storage_engine = InnoDB;

-- =========================
-- DATABASE
-- =========================
CREATE DATABASE IF NOT EXISTS shuttlezone;
USE shuttlezone;

-- =========================
-- DROP TABLES (ORDER MATTERS)
-- =========================
DROP TABLE IF EXISTS court_timers;
DROP TABLE IF EXISTS kiosk_pending_payments;
DROP TABLE IF EXISTS transactions;
DROP TABLE IF EXISTS equipment;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS members;
DROP TABLE IF EXISTS courts;

-- =========================
-- COURTS
-- =========================
CREATE TABLE courts (
    court_id INT AUTO_INCREMENT PRIMARY KEY,
    court_name VARCHAR(50),
    status ENUM('Operational', 'Under Maintenance', 'Out of Service', 'In Use') DEFAULT 'Operational',
    price_per_hour DECIMAL(8,2) NOT NULL,
    VAT_rate DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    member_discount DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    status_reason VARCHAR(255) DEFAULT NULL
);

INSERT INTO courts (court_id, court_name, status, price_per_hour, VAT_rate, member_discount) VALUES
(1, 'Court A', 'Under Maintenance', 35.00, 15.00, 15.00),
(2, 'Court B', 'Out of Service', 25.00, 15.00, 10.00),
(3, 'Court C', 'Operational', 15.00, 15.00, 5.00),
(1024, 'Court D', 'Under Maintenance', 20.00, 15.00, 10.00);

-- =========================
-- MEMBERS
-- =========================
CREATE TABLE members (
    id INT AUTO_INCREMENT PRIMARY KEY,
    member_code VARCHAR(16),
    name VARCHAR(255),
    email VARCHAR(255),
    phone VARCHAR(50),
    membership_type VARCHAR(100),
    expiry_date DATE,
    join_date DATE,
    is_archived TINYINT(1) DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- =========================
-- USERS
-- =========================
CREATE TABLE users (
    id VARCHAR(10) PRIMARY KEY,
    username VARCHAR(50) UNIQUE,
    full_name VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    role ENUM('Admin','Manager','Front Desk'),
    status ENUM('Active','Inactive') DEFAULT 'Active',
    password VARCHAR(100),
    profile_image VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO users (id, username, full_name, email, role, status, password, profile_image) VALUES
('U001', 'admin', 'System Administrator', 'admin@shuttlezone.local', 'Admin', 'Active', 'Admin@123', NULL),
('U002', 'manager01', 'Manager One', 'manager1@shuttlezone.local', 'Manager', 'Active', 'Manager@123', NULL),
('U003', 'frontdesk01', 'Front Desk One', 'frontdesk1@shuttlezone.local', 'Front Desk', 'Active', 'FrontDesk@123', NULL),
('U004', 'a', 'Quick Admin', 'a@shuttlezone.local', 'Admin', 'Active', 'a', NULL),
('U005', 'm', 'Quick Manager', 'm@shuttlezone.local', 'Manager', 'Active', 'm', NULL),
('U006', 'f', 'Quick FrontDesk', 'f@shuttlezone.local', 'Front Desk', 'Active', 'f', NULL);

-- =========================
-- EQUIPMENT
-- =========================
CREATE TABLE equipment (
    Id VARCHAR(50) PRIMARY KEY,
    Name VARCHAR(255),
    Category VARCHAR(255),
    Total INT DEFAULT 0,
    Available INT DEFAULT 0,
    Rented INT DEFAULT 0,
    Price DECIMAL(10,2) DEFAULT 0.00,
    Status VARCHAR(50) DEFAULT 'Available'
);

INSERT INTO equipment VALUES
('EQ001', 'Yonex Racket', 'Rackets', 10, 8, 2, 150.00, 'Available'),
('EQ002', 'Shuttlecock', 'Shuttlecocks', 50, 50, 0, 25.00, 'Available'),
('EQ003', 'Badminton Net', 'Nets', 5, 5, 0, 300.00, 'Available'),
('EQ004', 'Grip Tape', 'Accessories', 40, 40, 0, 5.50, 'Available'),
('EQ005', 'Scoreboard', 'Equipment', 2, 1, 1, 1200.00, 'In Use');

CREATE INDEX idx_equipment_category ON equipment(Category);
CREATE INDEX idx_equipment_status ON equipment(Status);

-- =========================
-- TRANSACTIONS
-- =========================
CREATE TABLE transactions (
    transaction_id INT AUTO_INCREMENT PRIMARY KEY,
    receipt_no VARCHAR(20),
    transaction_date DATE,
    transaction_time TIME,
    income_type ENUM('Court','Equipment','Membership','Other'),
    item_name VARCHAR(100),
    quantity INT DEFAULT 1,
    unit_price DECIMAL(10,2),
    total_amount DECIMAL(10,2) AS (quantity * unit_price) STORED,
    payment_method VARCHAR(50),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    court_id INT,
    transaction_source ENUM('Kiosk','Frontdesk') DEFAULT 'Frontdesk',
    FOREIGN KEY (court_id) REFERENCES courts(court_id)
        ON DELETE SET NULL ON UPDATE CASCADE
);

CREATE INDEX idx_transactions_date ON transactions(transaction_date);
CREATE INDEX idx_transactions_type_date ON transactions(income_type, transaction_date);

-- =========================
-- KIOSK PAYMENTS
-- =========================
CREATE TABLE kiosk_pending_payments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    stub_no VARCHAR(20),
    status ENUM('Pending','Completed','Cancelled') DEFAULT 'Pending',
    date_issued DATE,
    time_issued TIME,
    item_name VARCHAR(100),
    quantity INT DEFAULT 1,
    unit_price DECIMAL(10,2),
    total_amount DECIMAL(10,2) AS (quantity * unit_price) STORED
);

-- =========================
-- COURT TIMERS (AFTER courts + transactions)
-- =========================
CREATE TABLE court_timers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    court_id INT NOT NULL,
    transaction_id INT NOT NULL,
    start_time DATETIME NOT NULL,
    duration_minutes INT NOT NULL,
    end_time DATETIME NOT NULL,
    time_remaining_minutes INT NOT NULL,
    status VARCHAR(20) DEFAULT 'active',

    FOREIGN KEY (court_id) REFERENCES courts(court_id)
);

-- =========================
-- FINALIZE
-- =========================
SET foreign_key_checks = 1;