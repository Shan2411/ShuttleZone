-- Create and use the database
CREATE DATABASE IF NOT EXISTS `shuttlezone`;
USE `shuttlezone`;

DROP table if exists court_timers;
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