import React from "react";
import { TableCellContainer } from "./styles";

export type TableCellProps = {
    value: string;
}

export const TableCell: React.FC<TableCellProps> = (props: TableCellProps) => {
    return (
        <TableCellContainer>
            {props.value}
        </TableCellContainer>
    )
}