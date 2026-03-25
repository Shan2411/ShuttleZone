-- SQL Schema for transactions table
-- Add this to your existing shuttlezone database
-- Run this in phpMyAdmin after schema.md

SET NAMES utf8mb4;
SET time_zone = '+00:00';
SET foreign_key_checks = 0;
SET default_storage_engine = InnoDB;

USE shuttlezone;

--
-- Table structure for table transactions
--

DROP TABLE IF EXISTS transactions;
CREATE TABLE transactions (
    transaction_id   INT           AUTO_INCREMENT PRIMARY KEY,
    receipt_no       VARCHAR(20)   NOT NULL,
    transaction_date DATE          NOT NULL,
    transaction_time TIME          NOT NULL,
    income_type      ENUM('Court','Equipment','Membership','Other') NOT NULL,
    item_name        VARCHAR(100)  NOT NULL,
    quantity         INT           NOT NULL DEFAULT 1,
    unit_price       DECIMAL(10,2) NOT NULL,
    total_amount     DECIMAL(10,2) NOT NULL,
    payment_method   VARCHAR(50)   NOT NULL,
    created_at       DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,
    court_id         INT           NULL,
    CONSTRAINT fk_transactions_court
        FOREIGN KEY (court_id) REFERENCES courts(court_id)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for fast date-range queries used in Reports
--

CREATE INDEX idx_transactions_date
    ON transactions (transaction_date);

CREATE INDEX idx_transactions_type_date
    ON transactions (income_type, transaction_date);